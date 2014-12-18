using System;
using CTripOSS.Baiji.Generator.Context;

namespace CTripOSS.Baiji.Generator.Java.Context
{
    internal class JavaDocumentContext : DocumentContext
    {
        public JavaDocumentContext(Uri uri, string @namespace, GeneratorConfig generatorConfig,
            TypeRegistry typeRegistry)
            : base(uri, @namespace, generatorConfig, typeRegistry, new JavaTypeMangler())
        {
            TypeConverter.RegisterConverter(new JavaBaseConverter());
            TypeConverter.RegisterConverter(new JavaIdentifierConverter(TypeConverter));
            TypeConverter.RegisterConverter(new JavaListConverter(TypeConverter));
            TypeConverter.RegisterConverter(new JavaMapConverter(TypeConverter));
        }

        #region Overrides of DocumentContext
        public override TemplateContextGenerator TemplateContextGenerator
        {
            get
            {
                return new JavaTemplateContextGenerator(_generatorConfig, TypeRegistry, TypeConverter, TypeMangler,
                    Namespace);
            }
        }

        protected override string EffectiveNamespace
        {
            get
            {
                string effectiveNamespace = "baiji";
                if (_generatorConfig.ContainsTweak(JavaGeneratorTweak.USE_PLAIN_JAVA_NAMESPACE))
                {
                    effectiveNamespace = "java";
                }
                return effectiveNamespace;
            }
        }
        #endregion
    }
}