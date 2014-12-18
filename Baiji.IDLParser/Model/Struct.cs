using System.Collections.Generic;
using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public class Struct : Definition, Visitable
    {
        public Struct(string[] docStringLines, string name, List<BaijiField> fields, IList<Annotation> annotations)
        {
            DocStringLines = docStringLines;
            Name = Enforce.IsNotNull(name, "name");
            Fields = Enforce.IsNotNull(fields, "fields");
            Annotations = annotations;
        }

        public IList<BaijiField> Fields
        {
            get;
            private set;
        }

        public bool IsServiceResponse
        {
            get;
            set;
        }

        public bool HasResponseStatus
        {
            get;
            set;
        }

        public bool HasMobileRequestHead
        {
            get;
            set;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}