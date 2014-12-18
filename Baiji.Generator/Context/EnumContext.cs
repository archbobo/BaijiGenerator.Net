using System.Collections.Generic;

namespace CTripOSS.Baiji.Generator.Context
{
    public class EnumContext : CodeContext
    {
        public EnumContext(string[] docStringLines, string @namespace, string name)
        {
            DocStringLines = docStringLines;
            Namespace = @namespace;
            TypeName = name;
            Fields = new List<EnumFieldContext>();
        }

        public string[] DocStringLines
        {
            get;
            private set;
        }

        public string Namespace
        {
            get;
            private set;
        }

        public string TypeName
        {
            get;
            private set;
        }

        public IList<EnumFieldContext> Fields
        {
            get;
            private set;
        }

        public void AddField(EnumFieldContext field)
        {
            Fields.Add(field);
        }
    }
}