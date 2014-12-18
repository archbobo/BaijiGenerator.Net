using CTripOSS.Baiji.Generator.Context;

namespace CTripOSS.Baiji.Generator.Java.Context
{
    internal class JavaFieldContext : FieldContext
    {
        public JavaFieldContext(string idlName, GenType genType) : base(idlName, genType)
        {
        }

        public JavaFieldContext(string[] docStringLines, string idlName, string codeName, string getterName,
            string setterName, bool required, GenType genType)
            : base(docStringLines, idlName, codeName, required, genType)
        {
            GetterName = getterName;
            SetterName = setterName;
        }

        public string GetterName
        {
            get;
            private set;
        }

        public string SetterName
        {
            get;
            private set;
        }
    }
}