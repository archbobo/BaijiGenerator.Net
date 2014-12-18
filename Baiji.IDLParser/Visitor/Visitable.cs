namespace CTripOSS.Baiji.IDLParser.Visitor
{
    public interface Visitable
    {
        void Accept(IVisitor visitor);
    }
}