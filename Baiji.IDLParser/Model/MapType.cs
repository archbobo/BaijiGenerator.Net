using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public class MapType : ContainerType, Visitable
    {
        public MapType(BaijiType keyType, BaijiType valueType)
        {
            KeyType = Enforce.IsNotNull(keyType, "keyType");
            ValueType = Enforce.IsNotNull(valueType, "valueType");
        }

        public BaijiType KeyType
        {
            get;
            private set;
        }

        public BaijiType ValueType
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