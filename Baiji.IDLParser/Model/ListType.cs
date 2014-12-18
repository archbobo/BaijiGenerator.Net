using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public class ListType : ContainerType, Visitable
    {
        public BaijiType Type
        {
            get;
            private set;
        }

        public ListType(BaijiType type)
        {
            Type = Enforce.IsNotNull(type, "type");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}