using CTripOSS.Baiji.Generator.Context;

namespace CTripOSS.Baiji.Generator.CSharp.Context
{
    internal class CSharpFieldContext : FieldContext
    {
        public CSharpFieldContext(string idlName, GenType genType) : base(idlName, genType)
        {
        }

        public CSharpFieldContext(string[] docStringLines, string idlName, string codeName,
            string propertyName, bool required, GenType genType)
            : base(docStringLines, idlName, codeName, required, genType)
        {
            PropertyName = propertyName;
        }

        public string PropertyName
        {
            get;
            private set;
        }
    }
}