using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Antlr4.StringTemplate;
using CTripOSS.Baiji.Generator.Context;
using CTripOSS.Baiji.Generator.Util;
using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Model;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.Generator.Visitor
{
    /// <summary>
    /// Generate  source by visiting the document model
    /// </summary>
    public abstract class CodeGenerator : IVisitor
    {
        protected readonly DirectoryInfo _outputFolder;
        protected readonly TemplateLoader _templateLoader;
        protected readonly TemplateContextGenerator _contextGenerator;
        protected readonly GeneratorConfig _config;

        protected CodeGenerator(TemplateLoader templateLoader, DocumentContext context,
            GeneratorConfig config, DirectoryInfo outputFolder)
        {
            _outputFolder = outputFolder;
            _templateLoader = templateLoader;
            _contextGenerator = context.TemplateContextGenerator;
            _config = config;
        }

        protected abstract string FileExtension
        {
            get;
        }

        protected abstract string GenServiceTweak
        {
            get;
        }

        protected abstract string GenClientTweak
        {
            get;
        }

        protected abstract IDictionary<string, bool> GetTweakMap();

        protected void Render(CodeContext context, string templateName, string overridenFileExtension = null)
        {
            var template = _templateLoader.Load(templateName);
            Enforce.IsNotNull(template, string.Format("No template for '{0}' found!", templateName));
            template.Add("context", context);

            var tweakMap = GetTweakMap();
            template.Add("tweaks", tweakMap);

            var globalValues = new Dictionary<string, string>();
            var codeGenVersion = Assembly.GetExecutingAssembly().GetName().Version;
            globalValues.Add("CodeGenVersion", codeGenVersion.ToString());
            template.Add("global", globalValues);

            var filename = GetOutputFileName(context, overridenFileExtension ?? FileExtension);

            using (var writer = new StreamWriter(filename, false /*, Encoding.UTF8*/))
            {
                template.Write(new AutoIndentWriter(writer));
                writer.Flush();
            }
        }

        public void Visit(BaseType type)
        {
            throw new NotSupportedException();
        }

        public void Visit(Document document)
        {
            foreach (var definition in document.Definitions)
            {
                if (definition is Struct)
                {
                    Visit((Struct)definition);
                }
                else if (definition is IntegerEnum)
                {
                    Visit((IntegerEnum)definition);
                }
                else if (definition is Service)
                {
                    Visit((Service)definition);
                }
            }
        }

        public void Visit(Header header)
        {
            throw new NotSupportedException();
        }

        public void Visit(IdentifierType identifierType)
        {
            throw new NotSupportedException();
        }

        public virtual void Visit(IntegerEnum integerEnum)
        {
            var enumContext = GetEnumContext(integerEnum);

            Render(enumContext, "intEnum", null);
        }

        protected EnumContext GetEnumContext(IntegerEnum integerEnum)
        {
            var enumContext = _contextGenerator.EnumFromIdl(integerEnum);

            foreach (var field in integerEnum.Fields)
            {
                enumContext.AddField(_contextGenerator.FieldFromIdl(field));
            }
            return enumContext;
        }

        public void Visit(IntegerEnumField integerEnumField)
        {
            throw new NotSupportedException();
        }

        public void Visit(ListType listType)
        {
            throw new NotSupportedException();
        }

        public void Visit(MapType mapType)
        {
            throw new NotSupportedException();
        }

        public void Visit(Service service)
        {
            if (!string.IsNullOrEmpty(GenServiceTweak) && _config.ContainsTweak(GenServiceTweak))
            {
                EnsureCheckHealthAvail(service);
                var serviceContext = _contextGenerator.ServiceFromIdl(service);
                Render(serviceContext, "service");
            }
            if (!string.IsNullOrEmpty(GenClientTweak) && _config.ContainsTweak(GenClientTweak))
            {
                var clientContext = _contextGenerator.ClientFromIdl(service);
                Render(clientContext, "client");
            }
        }

        private void EnsureCheckHealthAvail(Service service)
        {
            var checkHealthMethod = service.Methods.FirstOrDefault(m => m.Name.ToLower().Equals("checkhealth"));
            if (checkHealthMethod == null)
            {
                throw new ArgumentException(string.Format("checkHealth method is mandatory for service {0}.",
                    service.Name));
            }

            if (!checkHealthMethod.ArgumentType.Name.EndsWith("CheckHealthRequestType"))
            {
                throw new ArgumentException(string.Format("The parameter type of {0}.{1} method must be CheckHealthRequestType from common types.",
                   checkHealthMethod.Name, service.Name));
            }
            if (!checkHealthMethod.ReturnType.Name.EndsWith("CheckHealthResponseType"))
            {
                throw new ArgumentException(string.Format("The parameter type of {0}.{1} method must be CheckHealthResponseType from common types.",
                   checkHealthMethod.Name, service.Name));
            }
        }
         
        public virtual void Visit(Struct @struct)
        {
            var structContext = GetStructContext(@struct);

            Render(structContext, "struct", null);
        }

        protected StructContext GetStructContext(Struct @struct)
        {
            var structContext = _contextGenerator.StructFromIdl(@struct);

            if (@struct.IsServiceResponse && !@struct.HasResponseStatus)
            {
                var message =
                    @struct.Name +
                    " must have a responseStatus field with ResponseStatusType in order to be used as a service response.";
                throw new ArgumentException(message);
            }

            return structContext;
        }

        public void Visit(BaijiField field)
        {
            throw new NotSupportedException();
        }

        public void Visit(BaijiMethod method)
        {
            throw new NotSupportedException();
        }

        protected virtual string GetOutputFileName(CodeContext context, string fileExtension)
        {
            var packages = context.Namespace.Split('.');
            DirectoryInfo folder = _outputFolder;

            foreach (string pkg in packages)
            {
                folder = folder.CreateSubdirectory(pkg);
            }

            var filename = Path.Combine(folder.FullName, context.TypeName + fileExtension);

            return filename;
        }
    }
}