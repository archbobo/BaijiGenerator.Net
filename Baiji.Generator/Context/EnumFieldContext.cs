namespace CTripOSS.Baiji.Generator.Context
{
    public class EnumFieldContext
    {
        public EnumFieldContext(string[] docStringLines, string name, long value)
        {
            DocStringLines = docStringLines;
            Name = name;
            Value = value;
        }

        public string[] DocStringLines
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public long Value
        {
            get;
            private set;
        }
    }
}