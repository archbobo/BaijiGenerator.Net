namespace CTripOSS.Baiji.Generator.Context
{
    public class MethodContext
    {
        public MethodContext(string[] docStringLines, string idlName, bool oneway, string codeName,
            string returnType, string argumentName, string argumentType)
        {
            DocStringLines = docStringLines;
            IdlName = idlName;
            Oneway = oneway;
            CodeName = codeName;
            ReturnType = returnType;
            ArgumentName = argumentName;
            ArgumentType = argumentType;
        }

        public string IdlName
        {
            get;
            private set;
        }

        public bool Oneway
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

        public string ReturnType
        {
            get;
            private set;
        }

        public string ArgumentName
        {
            get;
            private set;
        }

        public string ArgumentType
        {
            get;
            private set;
        }
    }
}