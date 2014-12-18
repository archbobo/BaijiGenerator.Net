using System.Collections.Generic;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public abstract class Definition
    {
        public string[] DocStringLines
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public IList<Annotation> Annotations
        {
            get;
            protected set;
        }
    }
}