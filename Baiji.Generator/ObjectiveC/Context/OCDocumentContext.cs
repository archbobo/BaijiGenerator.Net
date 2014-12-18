using System;
using CTripOSS.Baiji.Generator.Context;

namespace CTripOSS.Baiji.Generator.ObjectiveC.Context
{
    internal class OCDocumentContext : DocumentContext
    {
        public OCDocumentContext(Uri uri, string @namespace, GeneratorConfig generatorConfig,
            TypeRegistry typeRegistry)
            : base(uri, @namespace, generatorConfig, typeRegistry, new OCTypeMangler())
        {
            TypeConverter.RegisterConverter(new OCBaseConverter());
            TypeConverter.RegisterConverter(new OCIdentifierConverter(TypeConverter));
            TypeConverter.RegisterConverter(new OCListConverter(TypeConverter));
            TypeConverter.RegisterConverter(new OCMapConverter(TypeConverter));
        }

        #region Overrides of DocumentContext
        public override TemplateContextGenerator TemplateContextGenerator
        {
            get
            {
                return new OCTemplateContextGenerator(_generatorConfig, TypeRegistry, TypeConverter, TypeMangler,
                    Namespace);
            }
        }

        protected override string EffectiveNamespace
        {
            get
            {
                string effectiveNamespace = "baiji";
                if (_generatorConfig.ContainsTweak(OCGeneratorTweak.USE_PLAIN_JAVA_NAMESPACE))
                {
                    effectiveNamespace = "objc";
                }
                return effectiveNamespace;
            }
        }
        #endregion
    }
}
