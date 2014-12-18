using CTripOSS.Baiji.Generator.Context;

namespace CTripOSS.Baiji.Generator.ObjectiveC.Context
{
    internal class OCFieldContext : FieldContext
    {
        public OCFieldContext(string idlName, GenType genType)
            : base(idlName, genType)
        {
        }

        public OCFieldContext(string[] docStringLines, string idlName, string codeName,
            bool required, GenType genType)
            : base(docStringLines, idlName, codeName, required, genType)
        {
        }
    }
}
