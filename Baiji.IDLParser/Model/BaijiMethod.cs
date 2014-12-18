using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public class BaijiMethod : Visitable
    {
        public BaijiMethod(string[] docStringLines, string name, IdentifierType returnType, IdentifierType argumentType,
            string argumentName)
        {
            DocStringLines = docStringLines;
            Name = Enforce.IsNotNull(name, "name");
            ReturnType = Enforce.IsNotNull(returnType, "returnType");
            ArgumentType = Enforce.IsNotNull(argumentType, "argumentType");
            ArgumentName = Enforce.IsNotNull(argumentName, "argumentName");
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

        public IdentifierType ReturnType
        {
            get;
            private set;
        }

        public IdentifierType ArgumentType
        {
            get;
            private set;
        }

        public string ArgumentName
        {
            get;
            private set;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}