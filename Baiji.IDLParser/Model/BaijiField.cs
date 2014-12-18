using System.Collections.Generic;
using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public enum Required
    {
        REQUIRED,
        OPTIONAL,
        NONE
    }

    public class BaijiField : Definition, Visitable
    {
        public BaijiField(string[] docStringLines, string name, BaijiType type, Required required,
            IList<Annotation> annotations)
        {
            DocStringLines = docStringLines;
            Name = Enforce.IsNotNull(name, "name");
            Type = Enforce.IsNotNull(type, "type");
            Required = required;
            Annotations = annotations;
        }

        public BaijiType Type
        {
            get;
            private set;
        }

        public Required Required
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