using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public class IdentifierType : BaijiType, Visitable
    {
        public string Name
        {
            get;
            private set;
        }

        public IdentifierType(string name)
        {
            Name = Enforce.IsNotNull(name, "name");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}