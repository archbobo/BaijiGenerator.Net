using CTripOSS.Baiji.Helper;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public class Annotation
    {
        public Annotation(string name, string value)
        {
            Name = Enforce.IsNotNull(name, "name");
            Value = value;
        }

        public string Name
        {
            get;
            private set;
        }

        public string Value
        {
            get;
            private set;
        }
    }
}