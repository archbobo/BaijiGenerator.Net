using System.Collections.Generic;
using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.IDLParser.Model
{
    public class Header : Visitable
    {
        public Header(IList<string> includes, string defaultNamepace, IDictionary<string, string> namespaces)
        {
            Includes = Enforce.IsNotNull(includes, "includes");
            DefaultNamespace = defaultNamepace;
            Namespaces = Enforce.IsNotNull(namespaces, "namespaces");
        }

        public IList<string> Includes
        {
            get;
            private set;
        }

        public IDictionary<string, string> Namespaces
        {
            get;
            private set;
        }

        public string DefaultNamespace
        {
            get;
            private set;
        }

        public string GetNamespace(string nameSpaceName)
        {
            string ns;
            Namespaces.TryGetValue(nameSpaceName, out ns);
            return ns ?? DefaultNamespace;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}