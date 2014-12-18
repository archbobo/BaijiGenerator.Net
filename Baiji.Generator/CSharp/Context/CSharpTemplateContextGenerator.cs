using CTripOSS.Baiji.Generator.Context;
using CTripOSS.Baiji.IDLParser.Model;

namespace CTripOSS.Baiji.Generator.CSharp.Context
{
    internal class CSharpTemplateContextGenerator : TemplateContextGenerator
    {
        public CSharpTemplateContextGenerator(GeneratorConfig generatorConfig, TypeRegistry typeRegistry,
            TypeConverter typeConverter, ITypeMangler typeMangler, string defaultNamespace)
            : base(generatorConfig, typeRegistry, typeConverter, typeMangler, defaultNamespace)
        {
        }

        public override FieldContext FieldFromIdl(BaijiField field)
        {
            var context = new CSharpFieldContext(field.DocStringLines,
                field.Name,
                _typeMangler.MangleFieldName(field.Name),
                _typeMangler.MangleTypeName(field.Name),
                field.Required == Required.REQUIRED,
                _typeConverter.ConvertToGenType(field.Type));
            return context;
        }
    }
}