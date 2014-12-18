using System.Collections.Generic;
using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public class IntegerEnum : Definition, Visitable
    {
        public IntegerEnum(string[] docStringLines, string name, IList<IntegerEnumField> fields,
            IList<Annotation> annotations)
        {
            DocStringLines = docStringLines;
            Name = Enforce.IsNotNull(name, "name");
            Fields = Enforce.IsNotNull(fields, "fields");
            Annotations = annotations;
        }

        public IList<IntegerEnumField> Fields
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