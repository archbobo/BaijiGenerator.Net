using System;

namespace CTripOSS.Baiji.Generator.Context
{
    public class FieldContext : IComparable
    {
        public FieldContext(string idlName, GenType genType)
        {
            IdlName = idlName;
            GenType = genType;
        }

        public FieldContext(string[] docStringLines,
            string idlName,
            string codeName,
            bool required,
            GenType genType)
        {
            DocStringLines = docStringLines;
            IdlName = idlName;
            CodeName = codeName;
            Required = required;
            GenType = genType;
        }

        public string IdlName
        {
            get;
            private set;
        }

        public string[] DocStringLines
        {
            get;
            private set;
        }

        public string CodeName
        {
            get;
            private set;
        }

        public bool Required
        {
            get;
            private set;
        }

        public GenType GenType
        {
            get;
            private set;
        }

        public int CompareTo(object obj)
        {
            return string.Compare(IdlName, ((FieldContext)obj).IdlName, StringComparison.InvariantCulture);
        }
    }
}