using CTripOSS.Baiji.Generator.Util;
using CTripOSS.Baiji.Generator.Visitor;
using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Model;
using CTripOSS.Baiji.IDLParser.Visitor;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CTripOSS.Baiji.Generator
{
    /// <summary>
    /// Parses an IDL file and writes out code files.
    /// </summary>
    public abstract class Generator
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(Generator));

        protected readonly TemplateLoader _templateLoader;
        protected GeneratorConfig _generatorConfig;
        protected DirectoryInfo _outputFolder;

        //config value change at runtime?
        protected Generator(GeneratorConfig generatorConfig, IDictionary<string, IList<string>> templates)
        {
            if (!templates.ContainsKey(generatorConfig.CodeFlavor))
            {
                throw new ArgumentException(string.Format("Templating type {0} is unknown!", generatorConfig.CodeFlavor));
            }
            _generatorConfig = generatorConfig;

            _outputFolder = generatorConfig.OutputFolder;
            if (_outputFolder != null && !_outputFolder.Exists)
            {
                _outputFolder.Create();
            }
            _templateLoader = new TemplateLoader(templates[generatorConfig.CodeFlavor]);
        }

        /// <summary>
        /// Create DocumentContexts based on the input IDL document.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// A list of all document contexts of the given input and documents its includes.
        /// Contexts of included documents come first, context of the given input document is the last element in the list.
        /// </returns>
        public IList<DocumentContext> GetContexts(Uri input)
        {
            if (input == null)
            {
                throw new ArgumentException("No input file");
            }

            LOG.Info(string.Format("Parsing IDL from {0}...", input));

            if (!input.IsAbsoluteUri)
            {
                Uri.TryCreate(_generatorConfig.InputBase, input, out input);
            }

            return ParseDocument(input);
        }

        public void Parse(Uri input)
        {
            var contexts = GetContexts(input);
            Parse(contexts);
        }

        public void Parse(Uri input, Service service, IList<BaijiMethod> selectedMethod)
        {
            var contexts = GetContexts(input);
            Pruner pruner = new Pruner(contexts);
            pruner.Prune(service, selectedMethod);
            Parse(contexts);
        }

        private void Parse(IList<DocumentContext> contexts)
        {
            MarkServiceResponseTypes(contexts);

            LOG.Info("IDL parsing complete, writing code files...");

            for (var i = 0; i < contexts.Count - 1; ++i)
            {
                GenerateFiles(contexts[i], false);
            }
            GenerateFiles(contexts[contexts.Count - 1], true);

            LOG.Info("Code generation complete.");
        }

        public void UpdateConfig(GeneratorConfig config)
        {
            _generatorConfig = config;
            _outputFolder = config.OutputFolder;
        }

        private IList<DocumentContext> ParseDocument(Uri uri,
            IList<DocumentContext> contexts = null,
            ISet<Uri> parsedUris = null,
            Stack<Uri> parentDocuments = null,
            TypeRegistry typeRegistry = null)
        {
            // This is only for the first call.
            contexts = contexts ?? new List<DocumentContext>();
            parsedUris = parsedUris ?? new HashSet<Uri>();
            parentDocuments = parentDocuments ?? new Stack<Uri>();
            typeRegistry = typeRegistry?? new TypeRegistry();

            if (uri == null || !uri.IsAbsoluteUri)
            {
                throw new ArgumentException("Only absolute URIs can be parsed!");
            }
            if (parentDocuments.Contains(uri))
            {
                throw new ArgumentException(string.Format("Input {0} recursively includes itself ({1})", uri,
                    string.Join(" -> ", parentDocuments) + " -> " + uri));
            }

            LOG.Debug(string.Format("Parsing {0}...", uri));

            var idlNamespace = ExtractNamespace(uri);
            if (string.IsNullOrWhiteSpace(idlNamespace))
            {
                throw new ArgumentException(string.Format("URI {0} can not be translated to a namespace", uri));
            }

            var context = CreateDocumentContext(uri, idlNamespace, _generatorConfig, typeRegistry);

            var document = context.Document;
            var header = document.Header;

            // Make a note that this document is a parent of all the documents included, directly or recursively
            parentDocuments.Push(uri);

            try
            {
                if (header != null)
                {
                    foreach (var include in header.Includes)
                    {
                        Uri includeUri;
                        Uri.TryCreate(_generatorConfig.InputBase, include, out includeUri);
                        ParseDocument(includeUri,
                            // If the includes should also generate code, pass the list of
                            // contexts down to the include parser, otherwise pass a null in
                            _generatorConfig.GenerateIncludedCode ? contexts : null,
                            parsedUris,
                            parentDocuments,
                            typeRegistry);
                    }
                }
            }
            finally
            {
                // Done parsing this document's includes, remove it from the parent chain
                parentDocuments.Pop();
            }

            // Make a note that we've already passed this document
            if (!parsedUris.Contains(uri))
            {
                CreateTypeVisitor(context.CodeNamespace, context).Visit(document);
                parsedUris.Add(uri);
                contexts.Add(context);
            }
            return contexts;
        }

        private void MarkServiceResponseTypes(IList<DocumentContext> contexts)
        {
            foreach (var context in contexts)
            {
                if (context.Document.Definitions == null)
                {
                    continue;
                }
                foreach (var service in context.Document.Definitions.OfType<Service>())
                {
                    foreach (var method in service.Methods)
                    {
                        var returnTypeName = method.ReturnType.Name;
                        var nameSegments = returnTypeName.Split('.');
                        if (nameSegments.Length != 2)
                        {
                            // Ignore locally referenced structs. They have been marked when parsing the document.
                            continue;
                        }
                        string contextName = nameSegments[0], structName = nameSegments[1];
                        var referredContext = contexts.FirstOrDefault(c => c.Namespace == contextName);
                        if (referredContext == null || referredContext.Document.Definitions == null)
                        {
                            continue;
                        }
                        var referredStruct = referredContext.Document.Definitions.OfType<Struct>()
                            .FirstOrDefault(s => s.Name == structName);
                        if (referredStruct != null)
                        {
                            referredStruct.IsServiceResponse = true;
                        }
                    }
                }
            }
        }

        private string ExtractNamespace(Uri uri)
        {
            var path = uri.AbsolutePath;
            var name = Path.GetFileNameWithoutExtension(path);
            Enforce.IsNotNull(name, string.Format("No namespace found in {0}", uri));
            return name.Replace(".", "_");
        }

        private void GenerateFiles(DocumentContext context, bool isRootContext)
        {
            if (!isRootContext && ContextUtils.IsCommon(context.CodeNamespace))
            {
                return;
            }

            LOG.Debug(string.Format("Generating code for {0}...", context.Namespace));

            Enforce.IsNotNull(_outputFolder, "The output folder was not set!");
            if (!_outputFolder.Exists)
            {
                _outputFolder.Create();
            }

            LOG.Debug(string.Format("Writing source files into {0} using {1} ...", _outputFolder,
                _generatorConfig.CodeFlavor));

            var codeGenerator = CreateCodeGenerator(context);
            codeGenerator.Visit(context.Document);
        }

        protected abstract IVisitor CreateCodeGenerator(DocumentContext context);

        protected abstract DocumentContext CreateDocumentContext(Uri uri, string idlNamespace, GeneratorConfig config,
            TypeRegistry typeRegistry);

        public virtual TypeVisitor CreateTypeVisitor(string codeNamespace, DocumentContext documentContext)
        {
            return new TypeVisitor(codeNamespace, documentContext);
        }
    }
}