using System;
using CTripOSS.Baiji.Generator.Context;

namespace CTripOSS.Baiji.Generator.CSharp.Context
{
    internal class CSharpDocumentContext : DocumentContext
    {
        public CSharpDocumentContext(Uri uri, string @namespace, GeneratorConfig generatorConfig,
            TypeRegistry typeRegistry)
            : base(uri, @namespace, generatorConfig, typeRegistry, new CSharpTypeMangler())
        {
            TypeConverter.RegisterConverter(new CSharpBaseConverter());
            TypeConverter.RegisterConverter(new CSharpIdentifierConverter(TypeConverter));
            TypeConverter.RegisterConverter(new CSharpListConverter(TypeConverter));
            TypeConverter.RegisterConverter(new CSharpMapConverter(TypeConverter));
        }

        #region Overrides of DocumentContext
        public override TemplateContextGenerator TemplateContextGenerator
        {
            get
            {
                return new CSharpTemplateContextGenerator(_generatorConfig, TypeRegistry, TypeConverter, TypeMangler,
                    Namespace);
            }
        }

        protected override string EffectiveNamespace
        {
            get
            {
                string effectiveNamespace = "baiji";
                if (_generatorConfig.ContainsTweak(CSharpGeneratorTweak.USE_PLAIN_CSHARP_NAMESPACE))
                {
                    effectiveNamespace = "csharp";
                }
                return effectiveNamespace;
            }
        }
        #endregion
    }
}