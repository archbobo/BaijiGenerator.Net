using System;
using System.Collections.Generic;
using CTripOSS.Baiji.IDLParser.Model;

namespace CTripOSS.Baiji.Generator.Java
{
    internal class JavaBaseConverter : TypeConverter.Converter
    {
        private static readonly Dictionary<BType, string> JAVA_PRIMITIVES_MAP;
        private static readonly Dictionary<BType, GenType.Type> GTYPE_BASETYPE_MAP;

        static JavaBaseConverter()
        {
            JAVA_PRIMITIVES_MAP = new Dictionary<BType, string>();
            JAVA_PRIMITIVES_MAP[BType.BOOL] = "Boolean";
            JAVA_PRIMITIVES_MAP[BType.I32] = "Integer";
            JAVA_PRIMITIVES_MAP[BType.I64] = "Long";
            JAVA_PRIMITIVES_MAP[BType.DOUBLE] = "Double";
            JAVA_PRIMITIVES_MAP[BType.STRING] = "String";
            JAVA_PRIMITIVES_MAP[BType.BINARY] = "byte[]";
            JAVA_PRIMITIVES_MAP[BType.DATETIME] = "java.util.Calendar";

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
            return JAVA_PRIMITIVES_MAP[baseType];
        }

        public GenType ConvertToGenType(BaijiType type, bool nullable)
        {
            var javaTypeName = ConvertToString(type, nullable);
            var baseType = ((BaseType)type).BType;
            var gType = GTYPE_BASETYPE_MAP[baseType];
            var genType = new GenType(gType, javaTypeName);
            return genType;
        }
    }

    internal class JavaIdentifierConverter : TypeConverter.Converter
    {
        private readonly TypeConverter _typeConverter;

        public JavaIdentifierConverter(TypeConverter typeConverter)
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

            var javaTypeName = idlNamespace + "." + _typeConverter.TypeMangler.MangleTypeName(idlName);
            var javaType = _typeConverter.TypeRegistry.FindType(javaTypeName);
            return javaType;
        }

        public string ConvertToString(BaijiType type, bool nullable)
        {
            var javaType = FindCodeTypeFromIdentifierType((IdentifierType)type);
            return ShortenClassName(javaType.FullName);
        }

        private string ShortenClassName(string className)
        {
            // If the class is in the package we are currently generating code for, generate
            // only the simple name, otherwise generate the fully qualified class name.
            if (className.StartsWith(_typeConverter.CodeNamespace) &&
                className.LastIndexOf(".") == _typeConverter.CodeNamespace.Length)
            {
                className = className.Substring(_typeConverter.CodeNamespace.Length + 1);
            }
            return className;
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

    internal class JavaListConverter : TypeConverter.Converter
    {
        private readonly TypeConverter typeToJavaConverter;

        public JavaListConverter(TypeConverter typeToJavaConverter)
        {
            this.typeToJavaConverter = typeToJavaConverter;
        }

        public bool Accept(BaijiType type)
        {
            return type.GetType() == typeof(ListType);
        }

        public string ConvertToString(BaijiType type, bool nullable)
        {
            var listType = type as ListType;
            string actualType = typeToJavaConverter.ConvertToString(listType.Type, false);
            return "List<" + actualType + ">";
        }

        public GenType ConvertToGenType(BaijiType type, bool nullable)
        {
            var javaTypeName = ConvertToString(type, nullable);

            var listType = type as ListType;
            var genType = new GenType(GenType.Type.List, javaTypeName);
            genType.ElementType = typeToJavaConverter.ConvertToGenType(listType.Type, false);
            genType.ElementTypeName = typeToJavaConverter.ConvertToString(listType.Type, false);
            return genType;
        }
    }

    internal class JavaMapConverter : TypeConverter.Converter
    {
        private readonly TypeConverter typeToJavaConverter;

        public JavaMapConverter(TypeConverter typeToJavaConverter)
        {
            this.typeToJavaConverter = typeToJavaConverter;
        }

        public bool Accept(BaijiType type)
        {
            return type.GetType() == typeof(MapType);
        }

        public string ConvertToString(BaijiType type, bool nullable)
        {
            var mapType = type as MapType;

            string actualKeyType = typeToJavaConverter.ConvertToString(mapType.KeyType, false);
            string actualValueType = typeToJavaConverter.ConvertToString(mapType.ValueType, false);

            return string.Format("Map<{0}, {1}>", actualKeyType, actualValueType);
        }

        public GenType ConvertToGenType(BaijiType type, bool nullable)
        {
            var javaTypeName = ConvertToString(type, nullable);

            var mapType = type as MapType;
            var genType = new GenType(GenType.Type.Map, javaTypeName);
            genType.KeyType = typeToJavaConverter.ConvertToGenType(mapType.KeyType, false);
            genType.KeyTypeName = typeToJavaConverter.ConvertToString(mapType.KeyType, false);
            genType.ValueType = typeToJavaConverter.ConvertToGenType(mapType.ValueType, false);
            genType.ValueTypeName = typeToJavaConverter.ConvertToString(mapType.ValueType, false);
            return genType;
        }
    }
}