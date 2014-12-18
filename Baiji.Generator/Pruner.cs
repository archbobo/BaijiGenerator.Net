using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Model;
using System;
using System.Collections.Generic;

namespace CTripOSS.Baiji.Generator
{
    public class Pruner
    {
        private readonly IDictionary<string, int> _visited;
        private readonly IDictionary<string, DocPruner> _pruners;
        private readonly IDictionary<string, string> _modelCache;
        private readonly Queue<string> _visitingQueue;

        public Pruner(IEnumerable<DocumentContext> contexts)
        {
            _visited = new Dictionary<string, int>();
            _modelCache = new Dictionary<string, string>();
            _pruners = new Dictionary<string, DocPruner>();
            _visitingQueue = new Queue<string>();
            foreach (DocumentContext dc in contexts)
            {
                _pruners.Add(dc.Namespace,
                    new DocPruner(dc.Document, dc.Namespace, ref _modelCache, ref _visited, TryEnqueue));
            }
        }

        public void Prune(Service service, IList<BaijiMethod> selectedMethod)
        {
            foreach (var m in selectedMethod)
            {
                PrepareByMethod(m);
            }
            PruneModels();
            PruneService(service, selectedMethod);
        }

        protected void PruneService(Service service, IList<BaijiMethod> selectedMethod)
        {
            var prunedService = new Service(service.DocStringLines, service.Name, selectedMethod, service.Annotations);
            var pruner = FindPruner(service.Name);
            pruner.AddModel(prunedService);
        }

        protected void PruneModels()
        {
            while (_visitingQueue.Count > 0)
            {
                string modelName = _visitingQueue.Dequeue();
                var pruner = FindPruner(modelName);
                pruner.PruneModel(modelName);
            }
        }

        protected void PrepareByMethod(BaijiMethod method)
        {
            TryEnqueue(method.ArgumentType.Name);
            TryEnqueue(method.ReturnType.Name);
        }

        private DocPruner FindPruner(string modelName)
        {
            string prunerNamespace = _modelCache[modelName];
            var pruner = _pruners[prunerNamespace];
            if (pruner == null)
                throw new ArgumentException("Cannot find pruner for " + modelName);
            return pruner;
        }

        private void TryEnqueue(string typeName)
        {
            string[] splittedTypeName = typeName.Split('.');
            string modelName;
            if (splittedTypeName.Length == 1)
            {
                modelName = splittedTypeName[0];
            }
            else
            {
                modelName = splittedTypeName[1];
            }

            Enforce.IsNotNull<string>(modelName, typeName + " parsing failed.");

            if (_visited.ContainsKey(modelName) && _visited[modelName] == 0)
            {
                _visitingQueue.Enqueue(modelName);
                _visited[modelName] = 1;
            }
        }
    }
}
