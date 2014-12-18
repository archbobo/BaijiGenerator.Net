using CTripOSS.Baiji.IDLParser.Model;

namespace CTripOSS.Baiji.IDLParser.Visitor
{
    public interface IVisitor
    {
        void Visit(BaseType type);

        void Visit(Document document);

        void Visit(Header header);

        void Visit(IdentifierType identifierType);

        void Visit(IntegerEnum integerEnum);

        void Visit(IntegerEnumField integerEnumField);

        void Visit(ListType listType);

        void Visit(MapType mapType);

        void Visit(Service service);

        void Visit(Struct @struct);

        void Visit(BaijiField field);

        void Visit(BaijiMethod method);
    }
}