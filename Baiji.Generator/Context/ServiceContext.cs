using System.Collections.Generic;

namespace CTripOSS.Baiji.Generator.Context
{
    public class ServiceContext : CodeContext
    {
        public ServiceContext(string[] docStringLines, string idlName, string @namespace, string codeName,
            ISet<string> parents, string serviceName, string serviceNamespace)
        {
            DocStringLines = docStringLines;
            IdlName = idlName;
            Namespace = @namespace;
            TypeName = codeName;
            Parents = parents;
            ServiceName = serviceName;
            ServiceNamespace = serviceNamespace;
            Methods = new List<MethodContext>();
        }

        public string[] DocStringLines
        {
            get;
            private set;
        }

        public string IdlName
        {
            get;
            private set;
        }

        public string Namespace
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