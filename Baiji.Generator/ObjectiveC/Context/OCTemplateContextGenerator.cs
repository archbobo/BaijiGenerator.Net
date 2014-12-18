using CTripOSS.Baiji.Generator.Context;
using CTripOSS.Baiji.IDLParser.Model;

namespace CTripOSS.Baiji.Generator.ObjectiveC.Context
{
    internal class OCTemplateContextGenerator : TemplateContextGenerator
    {
        public OCTemplateContextGenerator(GeneratorConfig generatorConfig, TypeRegistry typeRegistry,
            TypeConverter typeConverter, ITypeMangler typeMangler, string defaultNamespace)
            : base(generatorConfig, typeRegistry, typeConverter, typeMangler, defaultNamespace)
        {
        }

        public override FieldContext FieldFromIdl(BaijiField field)
        {
            var fc = new OCFieldContext(field.DocStringLines,
                field.Name,
                _typeMangler.MangleMethodName(field.Name),
                field.Required == Required.REQUIRED,
                _typeConverter.ConvertToGenType(field.Type));
            return fc;
        }
    }
}
