using System;
using CTripOSS.Baiji.Generator.Context;
using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser;
using CTripOSS.Baiji.IDLParser.Model;

namespace CTripOSS.Baiji.Generator
{
    public abstract class DocumentContext
    {
        protected readonly GeneratorConfig _generatorConfig;
        protected readonly Uri _uri;

        protected DocumentContext(Uri uri, string @namespace, GeneratorConfig generatorConfig, TypeRegistry typeRegistry,
            ITypeMangler typeMangler)
        {
            Document = IdlParser.BuildDocument(uri);
            Namespace = @namespace;
            _uri = uri;
            _generatorConfig = generatorConfig;
            TypeRegistry = typeRegistry;
            TypeMangler = typeMangler;
            TypeConverter = new TypeConverter(typeRegistry, @namespace, CodeNamespace, TypeMangler);
        }

        public Document Document
        {
            get;
            private set;
        }

        public string Namespace
        {
            get;
            private set;
        }

        public TypeRegistry TypeRegistry
        {
            get;
            private set;
        }

        public TypeConverter TypeConverter
        {
            get;
            private set;
        }

        public ITypeMangler TypeMangler
        {
            get;
            private set;
        }

        public abstract TemplateContextGenerator TemplateContextGenerator
        {
            get;
        }

        public string CodeNamespace
        {
            get
            {
                string effectiveNamespace = EffectiveNamespace;

                // Override takes precedence
                string @namespace = _generatorConfig.OverrideNamespace;
                // Otherwise fallback on namespace specified in the IDL file
                if (@namespace == null && Document.Header != null &&
                    Document.Header.Namespaces.ContainsKey(effectiveNamespace))
                {
                    @namespace = Document.Header.Namespaces[effectiveNamespace];
                }
                // Or the default if we don't have an override package or a package in the IDL file
                if (@namespace == null)
                {
                    @namespace = _generatorConfig.DefaultNamespace;
                }

                // If none of the above options get us a package to use, fail
                Enforce.IsNotNull(@namespace,
                    string.Format("uri {0} does not include a '{1}' namespace!", _uri, effectiveNamespace));

                return @namespace;
            }
        }

        protected abstract string EffectiveNamespace
        {
            get;
        }
    }
}