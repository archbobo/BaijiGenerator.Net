using System.Collections.Generic;

namespace CTripOSS.Baiji.Generator.Context
{
    public class ClientContext : CodeContext
    {
        public ClientContext(string[] docStringLines, string name, string @namespace, string typeName,
            ISet<string> parents, string serviceName, string serviceNamespace)
        {
            DocStringLines = docStringLines;
            Name = name;
            Namespace = @namespace;
            TypeName = typeName;
            Parents = parents;
            ServiceName = serviceName;
            ServiceNamespace = serviceNamespace;
            Methods = new List<MethodContext>();
        }

        public string Name
        {
            get;
            private set;
        }

        public string Namespace
        {
            get;
            private set;
        }

        public string[] DocStringLines
        {
            get;
            private set;
        }

        public string TypeName
        {
            get;
            private set;
        }

        public ISet<string> Parents
        {
            get;
            private set;
        }

        public string ServiceName
        {
            get;
            private set;
        }

        public string ServiceNamespace
        {
            get;
            private set;
        }

        public IList<MethodContext> Methods
        {
            get;
            private set;
        }

        public void AddMethod(MethodContext method)
        {
            Methods.Add(method);
        }
    }
}