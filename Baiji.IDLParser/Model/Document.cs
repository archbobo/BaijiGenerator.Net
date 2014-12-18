using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Visitor;
using System.Collections.Generic;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public class Document : Visitable
    {
        public Header Header
        {
            get;
            private set;
        }

        public IList<Definition> Definitions
        {
            get;
            set;
        }

        public Document(Header header, IList<Definition> definitions)
        {
            //Header = header;
            Header = Enforce.IsNotNull(header, "header");
            Definitions = Enforce.IsNotNull(definitions, "definitions");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}