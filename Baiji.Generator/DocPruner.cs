
using CTripOSS.Baiji.IDLParser.Model;
using System;
using System.Collections.Generic;
namespace CTripOSS.Baiji.Generator
{
    internal class DocPruner
    {
        private readonly IDictionary<string, Definition> _modelCache;
        private readonly IList<Definition> _retainedModels;
        private readonly Document _doc;

        public delegate void EnqueueDelegate(string modelName);
        private EnqueueDelegate _enqueue;

        internal DocPruner(
            Document doc,
            string @namespace,
            ref IDictionary<string, string> modelMapping,
            ref IDictionary<string, int> visited,
            EnqueueDelegate enqueue)
        {
            _enqueue = enqueue;
            _doc = doc;
            _retainedModels = new List<Definition>();
            _modelCache = new Dictionary<string, Definition>();
            Cache(@namespace, ref modelMapping, ref visited);
            _doc.Definitions = _retainedModels;
        }

        private void Cache(string @namespace,
            ref IDictionary<string, string> modelMapping, ref IDictionary<string, int> visited)
        {
            foreach (Definition def in _doc.Definitions)
            {
                _modelCache.Add(def.Name, def);
                modelMapping.Add(def.Name, @namespace);
                visited.Add(def.Name, 0);
            }
        }

        public void PruneModel(string modelName)
        {
            if (!_modelCache.ContainsKey(modelName))
                throw new ArgumentException(modelName + "cannot be found!");
            var def = _modelCache[modelName];
            if (def.GetType() == typeof(Struct))
            {
                PruneModel(def as Struct);
            }
            if (def.GetType() == typeof(IntegerEnum))
            {
                PruneModel(def as IntegerEnum);
            }
        }

        public void AddModel(Definition def)
        {
            _retainedModels.Add(def);
        }

        protected void PruneModel(Struct structModel)
        {
            _retainedModels.Add(structModel);
            foreach (BaijiField field in structModel.Fields)
            {
                string fieldTypeName;
                FindDefNameByType(field.Type, out fieldTypeName);
                if (fieldTypeName != null)
                {
                    TryEnqueue(fieldTypeName);
                }
            }
        }

        protected void PruneModel(IntegerEnum enumModel)
        {
            _retainedModels.Add(enumModel);
        }

        private void FindDefNameByType(BaijiType type, out string structName)
        {
            structName = null;
            if (type.GetType() == typeof(BaseType))
                return;
            if (type.GetType() == typeof(ListType))
            {
                FindDefNameByType(((ListType)type).Type, out structName);
                return;
            }
            if (type.GetType() == typeof(MapType))
            {
                FindDefNameByType(((MapType)type).ValueType, out structName);
                return;
            }
            if (type.GetType() == typeof(IdentifierType))
            {
                structName = ((IdentifierType)type).Name;
                return;
            }
        }

        private void TryEnqueue(string modelName)
        {
            _enqueue(modelName);
        }
    }
}