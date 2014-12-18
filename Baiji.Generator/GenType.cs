namespace CTripOSS.Baiji.Generator
{
    public class GenType
    {
        public enum Type : byte
        {
            Bool = 0,
            Byte = 1,
            Double = 2,
            I32 = 4,
            I64 = 5,
            String = 6,
            Binary = 7,
            Struct = 8,
            Enum = 9,
            Map = 10,
            List = 12,
            DateTime = 13
        }

        public Type GType
        {
            get;
            private set;
        }

        public string TypeName
        {
            get;
            private set;
        }

        // for map key
        public GenType KeyType
        {
            get;
            set;
        }

        public string KeyTypeName
        {
            get;
            set;
        }

        // for map value
        public GenType ValueType
        {
            get;
            set;
        }

        public string ValueTypeName
        {
            get;
            set;
        }

        // for element type of List
        public GenType ElementType
        {
            get;
            set;
        }

        public string ElementTypeName
        {
            get;
            set;
        }

        public GenType(Type type, string typeName)
        {
            GType = type;
            TypeName = typeName;
        }

        public bool IsBool
        {
            get
            {
                return GType == Type.Bool;
            }
        }

        public bool IsByte
        {
            get
            {
                return GType == Type.Byte;
            }
        }

        public bool IsDouble
        {
            get
            {
                return GType == Type.Double;
            }
        }

        public bool IsI32
        {
            get
            {
                return GType == Type.I32;
            }
        }

        public bool IsI64
        {
            get
            {
                return GType == Type.I64;
            }
        }

        public bool IsBinary
        {
            get
            {
                return GType == Type.Binary;
            }
        }

        public bool IsString
        {
            get
            {
                return GType == Type.String;
            }
        }

        public bool IsEnum
        {
            get
            {
                return GType == Type.Enum;
            }
        }

        public bool IsStruct
        {
            get
            {
                return GType == Type.Struct;
            }
        }

        public bool IsList
        {
            get
            {
                return GType == Type.List;
            }
        }

        public bool IsMap
        {
            get
            {
                return GType == Type.Map;
            }
        }

        public bool IsBaseType
        {
            get
            {
                return GType == Type.Bool || GType == Type.Byte || GType == Type.Double || GType == Type.I32 ||
                       GType == Type.I64 || GType == Type.Binary || GType == Type.String || GType == Type.DateTime;
            }
        }

        public bool IsContainer
        {
            get
            {
                return GType == Type.List || GType == Type.Map;
            }
        }
    }
}