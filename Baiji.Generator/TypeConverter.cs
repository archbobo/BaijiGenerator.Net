using System;
using System.Collections.Generic;
using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Model;

namespace CTripOSS.Baiji.Generator
{
    public class TypeConverter
    {
        private readonly IList<Converter> _converters = new List<Converter>();

        public TypeConverter(TypeRegistry typeRegistry,
            string idlNamespace,
            string codeNamespace,
            ITypeMangler typeMangler)
        {
            Enforce.IsNotNull(typeRegistry, "typeRegistry");
            Enforce.IsNotNull(idlNamespace, "idlNamespace");
            TypeRegistry = typeRegistry;
            IdlNamespace = idlNamespace;
            CodeNamespace = codeNamespace;
            TypeMangler = typeMangler;
        }

        public string IdlNamespace
        {
            get;
            private set;
        }

        public TypeRegistry TypeRegistry
        {
            get;
            private set;
        }

        public string CodeNamespace
        {
            get;
            private set;
        }

        public ITypeMangler TypeMangler
        {
            get;
            private set;
        }

        public void RegisterConverter(Converter converter)
        {
            _converters.Add(converter);
        }

        public string ConvertToString(BaijiType type, bool nullable = true)
        {
            foreach (var converter in _converters)
            {
                if (converter.Accept(type))
                {
                    return converter.ConvertToString(type, nullable);
                }
            }
            throw new ArgumentException(string.Format("Baiji type {0} is unknown!", type));
        }

        public GenType ConvertToGenType(BaijiType type, bool nullable = true)
        {
            foreach (var converter in _converters)
            {
                if (converter.Accept(type))
                {
                    return converter.ConvertToGenType(type, nullable);
                }
            }
            throw new ArgumentException(string.Format("Baiji type {0} is unknown!", type));
        }

        public bool IsEnumIdentifier(IdentifierType id)
        {
            var type = FindCodeTypeFromIdentifierType(id);
            return type.IsEnum;
        }

        public bool IsStructIdentifier(IdentifierType id)
        {
            var type = FindCodeTypeFromIdentifierType(id);
            return type.IsStruct;
        }

        public CodeType FindCodeTypeFromIdentifierType(IdentifierType id)
        {
            return FindCodeTypeFromName(id.Name);
        }

        public CodeType FindCodeTypeFromName(string name)
        {
            // the name is [<namespace>.]<type>
            var names = new List<string>(name.Split('.'));

            if (names.Count == 0 || names.Count > 3)
            {
                throw new ArgumentException("Only unqualified and namespace qualified names are allowed!");
            }
            string idlName = names[0];
            string idlNamespace = IdlNamespace;

            if (names.Count == 2)
            {
                idlName = names[1];
                idlNamespace = names[0];
            }

            var typeName = idlNamespace + "." + TypeMangler.MangleTypeName(idlName);
            var type = TypeRegistry.FindType(typeName);
            return type;
        }

        public interface Converter
        {
            /// <summary>
            /// Return true if the converter accepts the proposed type.
            /// </summary>
            /// <param name="type">Baiji type</param>
            /// <returns>ture if accept, false otherwise</returns>
            bool Accept(BaijiType type);

            /// <summary>
            /// Convert the Baiji type into a string suitable for a code type.
            /// </summary>
            /// <param name="type">Baiji type</param>
            /// <param name="nullable">Whether to allow nullable for this type</param>
            /// <returns>string representation of code type</returns>
            string ConvertToString(BaijiType type, bool nullable);

            /// <summary>
            /// Convert the Baiji type into a code generation type model
            /// </summary>
            /// <param name="type">Baiji type</param>
            /// <param name="nullable">Whether to allow nullable for this type</param>
            /// <returns>a code type model</returns>
            GenType ConvertToGenType(BaijiType type, bool nullable);
        }
    }
}