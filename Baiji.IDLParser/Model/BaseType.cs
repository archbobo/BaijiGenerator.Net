using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public enum BType
    {
        BOOL,
        I32,
        I64,
        DOUBLE,
        STRING,
        BINARY,
        DATETIME
    }

    public class BaseType : BaijiType, Visitable
    {
        private readonly BType type;

        public BType BType { get { return type; } }

        public BaseType(BType type)
        {
            this.type = type;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
