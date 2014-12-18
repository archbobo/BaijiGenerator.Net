using System.Collections.Generic;
using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public class Service : Definition, Visitable
    {
        public Service(string[] docStringLines, string name, IList<BaijiMethod> methods, IList<Annotation> annotations)
        {
            DocStringLines = docStringLines;
            Name = Enforce.IsNotNull(name, "name");
            Methods = Enforce.IsNotNull(methods, "methods");
            Annotations = annotations;
        }

        public IList<BaijiMethod> Methods
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