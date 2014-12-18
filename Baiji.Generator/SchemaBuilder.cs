using System;
using System.Collections.Generic;
using CTripOSS.Baiji.IDLParser.Model;
using CTripOSS.Baiji.Schema;

namespace CTripOSS.Baiji.Generator
{
    public class SchemaBuilder
    {
        private static readonly IDictionary<BType, SchemaType> _bTypeMapping = new Dictionary<BType, SchemaType>
        {
            {BType.BOOL, SchemaType.Boolean},
            {BType.I32, SchemaType.Int},
            {BType.I64, SchemaType.Long},
            {BType.DOUBLE, SchemaType.Double},
            {BType.STRING, SchemaType.String},
            {BType.BINARY, SchemaType.Bytes},
            {BType.DATETIME, SchemaType.DateTime},
        };

        private readonly TypeConverter _typeConverter;

        private readonly ITypeMangler _typeMangler;

        public SchemaBuilder(TypeConverter typeConverter, ITypeMangler typeMangler)
        {
            _typeConverter = typeConverter;
            _typeMangler = typeMangler;
        }

        public string Build(CodeType type)
        {
            var schema = BuildSchema(type, new Dictionary<SchemaName, Schema.Schema>());
            return schema.ToString();
        }

        private Schema.Schema BuildSchema(CodeType type, IDictionary<SchemaName, Schema.Schema> parsedSchemas)
        {
            var schemaName = new SchemaName(type.Name, type.CodeNamespace, null);
            Schema.Schema schema;
            if (parsedSchemas.TryGetValue(schemaName, out schema))
            {
                return schema;
            }

            var definition = type.Definition;
            if (definition is Struct)
            {
                var record = new RecordSchema(schemaName, null, null, null, null, false);
                parsedSchemas[schemaName] = schema = record;

                int pos = 0;
                foreach (var idlField in ((Struct)definition).Fields)
                {
                    var actualFieldSchema = BuildSchema(type.IdlNamespace, idlField.Type, parsedSchemas);
                    var fieldSchema =
                        new UnionSchema(new[] {actualFieldSchema, PrimitiveSchema.NewInstance("null")},
                            null);
                    var field = new Field(fieldSchema, _typeMangler.MangleFieldName(idlField.Name), null, pos++, null,
                        null, Field.SortOrder.Ignore, null);
                    record.AddField(field);
                }
            }
            else if (definition is IntegerEnum)
            {
                var fields = ((IntegerEnum)definition).Fields;
                var symbols = new List<KeyValuePair<string, int?>>(fields.Count);
                foreach (var symbol in fields)
                {
                    symbols.Add(new KeyValuePair<string, int?>(symbol.Name, (int?)symbol.ExplicitValue));
                }
                parsedSchemas[schemaName] = schema = new EnumSchema(schemaName, null, null, symbols.ToArray(), null);
            }

            if (schema == null)
            {
                throw new NotSupportedException("Unsupport code type for schema generation: " + type);
            }
            return schema;
        }

        private Schema.Schema BuildSchema(string @namespace, BaijiType type, IDictionary<SchemaName, Schema.Schema> parsedSchema)
        {
            if (type is BaseType)
            {
                var baseType = (BaseType)type;
                return new PrimitiveSchema(_bTypeMapping[baseType.BType], null);
            }

            if (type is ListType)
            {
                var listType = (ListType)type;
                var itemSchema = BuildSchema(@namespace, listType.Type, parsedSchema);
                return new ArraySchema(itemSchema, null);
            }

            if (type is MapType)
            {
                var mapType = (MapType)type;
                var valueSchema = BuildSchema(@namespace, mapType.ValueType, parsedSchema);
                return new MapSchema(valueSchema, null);
            }

            if (type is IdentifierType)
            {
                var idType = (IdentifierType)type;
                string name = idType.Name;
                if (@namespace != _typeConverter.IdlNamespace && !name.Contains("."))
                {
                    name = @namespace + "." + name;
                }
                var codeType = _typeConverter.FindCodeTypeFromName(name);
                return BuildSchema(codeType, parsedSchema);
            }

            throw new NotSupportedException("Unknown BaijiType: " + type);
        }
    }
}