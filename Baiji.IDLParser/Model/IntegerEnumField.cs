using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public class IntegerEnumField : Visitable
    {
        private readonly long _effectiveValue;

        public IntegerEnumField(string[] docStringLines, string name, long? explicitValue, long defaultValue)
        {
            DocStringLines = docStringLines;
            Name = Enforce.IsNotNull(name, "name");
            ExplicitValue = explicitValue;
            _effectiveValue = explicitValue.HasValue ? explicitValue.Value : defaultValue;
        }

        public string[] DocStringLines
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public long? ExplicitValue
        {
            get;
            private set;
        }

        public long Value
        {
            get
            {
                return _effectiveValue;
            }
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}