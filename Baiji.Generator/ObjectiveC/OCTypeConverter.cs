using System;
using System.Collections.Generic;
using CTripOSS.Baiji.IDLParser.Model;
using System.Text;

namespace CTripOSS.Baiji.Generator.ObjectiveC
{
    internal class OCBaseConverter : TypeConverter.Converter
    {

        private static readonly Dictionary<BType, string> OC_PRIMITIVES_MAP;
        private static readonly Dictionary<BType, GenType.Type> GTYPE_BASETYPE_MAP;

        static OCBaseConverter()
        {
            OC_PRIMITIVES_MAP = new Dictionary<BType, string>();
            OC_PRIMITIVES_MAP[BType.BOOL] = "NSNumber";
            OC_PRIMITIVES_MAP[BType.I32] = "NSNumber";
            OC_PRIMITIVES_MAP[BType.I64] = "NSNumber";
            OC_PRIMITIVES_MAP[BType.DOUBLE] = "NSNumber";
            OC_PRIMITIVES_MAP[BType.STRING] = "NSString";
            OC_PRIMITIVES_MAP[BType.BINARY] = "NSData";
            OC_PRIMITIVES_MAP[BType.DATETIME] = "NSDate";

            GTYPE_BASETYPE_MAP = new Dictionary<BType, GenType.Type>();
            GTYPE_BASETYPE_MAP[BType.BOOL] = GenType.Type.Bool;
            GTYPE_BASETYPE_MAP[BType.I32] = GenType.Type.I32;
            GTYPE_BASETYPE_MAP[BType.I64] = GenType.Type.I64;
            GTYPE_BASETYPE_MAP[BType.DOUBLE] = GenType.Type.Double;
            GTYPE_BASETYPE_MAP[BType.STRING] = GenType.Type.String;
            GTYPE_BASETYPE_MAP[BType.BINARY] = GenType.Type.Binary;
            GTYPE_BASETYPE_MAP[BType.DATETIME] = GenType.Type.DateTime;
        }

        public bool Accept(BaijiType type)
        {
            return type.GetType() == typeof(BaseType);
        }

        public string ConvertToString(BaijiType type, bool nullable)
        {
            var baseType = ((BaseType)type).BType;
            return OC_PRIMITIVES_MAP[baseType];
        }

        public GenType ConvertToGenType(BaijiType type, bool nullable)
        {
            var ocTypeName = ConvertToString(type, nullable);
            var baseType = ((BaseType)type).BType;
            var gType = GTYPE_BASETYPE_MAP[baseType];
            var genType = new GenType(gType, ocTypeName);
            return genType;
        }
    }

    internal class OCIdentifierConverter : TypeConverter.Converter
    {
        private readonly TypeConverter _typeConverter;

        public OCIdentifierConverter(TypeConverter typeConverter)
        {
            _typeConverter = typeConverter;
        }

        public bool Accept(BaijiType type)
        {
            return type.GetType() == typeof(IdentifierType);
        }

        private CodeType FindCodeTypeFromIdentifierType(IdentifierType id)
        {
            var name = id.Name;
            // the name is [<namespace>.]<type>
            var names = new List<string>(name.Split('.'));

            if (names.Count == 0 || names.Count > 3)
            {
                throw new ArgumentException("Only unqualified and namespace qualified names are allowed!");
            }
            string idlName = names[0];
            string idlNamespace = _typeConverter.IdlNamespace;

            if (names.Count == 2)
            {
                idlName = names[1];
                idlNamespace = names[0];
            }

            var javaTypeName = idlNamespace + "." + idlName;
            var javaType = _typeConverter.TypeRegistry.FindType(javaTypeName);
            return javaType;
        }

        public string ConvertToString(BaijiType type, bool nullable)
        {
            var javaType = FindCodeTypeFromIdentifierType((IdentifierType)type);
            return javaType.Name;
        }

        private string ShortenClassName(string className)
        {
            // If the class is in the package we are currently generating code for, generate
            // only the simple name, otherwise generate the fully qualified class name.
            /*if (className.StartsWith(_typeConverter.CodeNamespace) &&
                className.LastIndexOf(".") == _typeConverter.CodeNamespace.Length)
            {
                className = className.Substring(_typeConverter.CodeNamespace.Length + 1);
            }*/
            StringBuilder sb = new StringBuilder(className);
            sb.Remove(className.LastIndexOf("."), 1);
            return sb.ToString();
        }

        public GenType ConvertToGenType(BaijiType type, bool nullable)
        {
            var javaTypeName = ConvertToString(type, nullable);
            var javaType = FindCodeTypeFromIdentifierType((IdentifierType)type);
            if (javaType.IsEnum)
            {
                return new GenType(GenType.Type.Enum, javaTypeName);
            }
            else
            {
                return new GenType(GenType.Type.Struct, javaTypeName);
            }
        }
    }

    internal class OCListConverter : TypeConverter.Converter
    {
        private readonly TypeConverter typeToOCConverter;

        public OCListConverter(TypeConverter typeToOCConverter)
        {
            this.typeToOCConverter = typeToOCConverter;
        }

        public bool Accept(BaijiType type)
        {
            return type.GetType() == typeof(ListType);
        }

        public string ConvertToString(BaijiType type, bool nullable)
        {
            var listType = type as ListType;
            string actualType = typeToOCConverter.ConvertToString(listType.Type, false);
            return "NSArray";
        }

        public GenType ConvertToGenType(BaijiType type, bool nullable)
        {
            var javaTypeName = ConvertToString(type, nullable);

            var listType = type as ListType;
            var genType = new GenType(GenType.Type.List, javaTypeName);
            genType.ElementType = typeToOCConverter.ConvertToGenType(listType.Type, false);
            genType.ElementTypeName = typeToOCConverter.ConvertToString(listType.Type, false);
            return genType;
        }
    }

    internal class OCMapConverter : TypeConverter.Converter
    {
        private readonly TypeConverter typeToOCConverter;

        public OCMapConverter(TypeConverter typeToOCConverter)
        {
            this.typeToOCConverter = typeToOCConverter;
        }

        public bool Accept(BaijiType type)
        {
            return type.GetType() == typeof(MapType);
        }

        public string ConvertToString(BaijiType type, bool nullable)
        {
            return "NSDictionary";
        }

        public GenType ConvertToGenType(BaijiType type, bool nullable)
        {
            var javaTypeName = ConvertToString(type, nullable);

            var mapType = type as MapType;
            var genType = new GenType(GenType.Type.Map, javaTypeName);
            genType.KeyType = typeToOCConverter.ConvertToGenType(mapType.KeyType, false);
            genType.KeyTypeName = typeToOCConverter.ConvertToString(mapType.KeyType, false);
            genType.ValueType = typeToOCConverter.ConvertToGenType(mapType.ValueType, false);
            genType.ValueTypeName = typeToOCConverter.ConvertToString(mapType.ValueType, false);
            return genType;
        }
    }
}
