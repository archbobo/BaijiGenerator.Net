using System;
using System.Collections;
using System.Collections.Generic;

namespace CTripOSS.Baiji.Generator
{
    /// <summary>
    /// Collects all the various custom types found in the IDL definition files.
    /// </summary>
    public class TypeRegistry : IEnumerable<CodeType>
    {
        private readonly IDictionary<string, CodeType> _registry = new Dictionary<string, CodeType>();

        public void AddAll(IEnumerable<CodeType> types)
        {
            foreach (var type in types)
            {
                Add(type);
            }
        }

        public void Add(CodeType type)
        {
            if (_registry.ContainsKey(type.Key))
            {
                throw new ArgumentException(string.Format("The type {0} was already registered!", type), "type");
            }
            _registry[type.Key] = type;
        }

        public IEnumerator<CodeType> GetEnumerator()
        {
            return _registry.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public CodeType FindType(string @namespace, string name)
        {
            if (name == null)
            {
                return null;
            }

            if (name.Contains("."))
            {
                // If the name contains a '.' it already has a namespace prepended
                return FindType(name);
            }
            else
            {
                // Otherwise, use the default namespace
                return FindType(@namespace + "." + name);
            }
        }

        public CodeType FindType(string key)
        {
            if (key == null)
            {
                return null;
            }
            CodeType type;
            if (!_registry.TryGetValue(key, out type))
            {
                var message = string.Format("Unable to find type with key {0} in registry!", key);
                throw new ArgumentException(message, "key");
            }
            return type;
        }
    }
}