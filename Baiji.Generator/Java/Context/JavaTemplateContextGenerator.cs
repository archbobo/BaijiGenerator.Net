using CTripOSS.Baiji.Generator.Context;
using CTripOSS.Baiji.IDLParser.Model;

namespace CTripOSS.Baiji.Generator.Java.Context
{
    internal class JavaTemplateContextGenerator : TemplateContextGenerator
    {
        public JavaTemplateContextGenerator(GeneratorConfig generatorConfig, TypeRegistry typeRegistry,
            TypeConverter typeConverter, ITypeMangler typeMangler, string defaultNamespace)
            : base(generatorConfig, typeRegistry, typeConverter, typeMangler, defaultNamespace)
        {
        }

        public override FieldContext FieldFromIdl(BaijiField field)
        {
            var fc = new JavaFieldContext(field.DocStringLines,
                field.Name,
                _typeMangler.MangleMethodName(field.Name),
                GetterName(field),
                SetterName(field),
                field.Required == Required.REQUIRED,
                _typeConverter.ConvertToGenType(field.Type));
            return fc;
        }

        private string GetterName(BaijiField field)
        {
            string type = _typeConverter.ConvertToString(field.Type);
            return ("Boolean".Equals(type) ? "is" : "get") + _typeMangler.MangleTypeName(field.Name);
        }

        private string SetterName(BaijiField field)
        {
            return "set" + _typeMangler.MangleTypeName(field.Name);
        }
    }
}