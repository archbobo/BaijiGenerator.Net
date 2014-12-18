using System;
using CTripOSS.Baiji.IDLParser.Model;
using CTripOSS.Baiji.IDLParser.Visitor;
using log4net;

namespace CTripOSS.Baiji.Generator.Visitor
{
    public class TypeVisitor : IVisitor
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(TypeVisitor));
        protected readonly string _codeNamespace;
        protected readonly DocumentContext _documentContext;

        public TypeVisitor(string codeNamespace, DocumentContext documentContext)
        {
            _codeNamespace = codeNamespace;
            _documentContext = documentContext;
        }

        public void Visit(BaseType type)
        {
            throw new NotImplementedException();
        }

        public void Visit(Document document)
        {
            foreach (var definition in document.Definitions)
            {
                var type = CreateCodeType(_documentContext.Namespace, definition.Name,
                    definition.Name, _codeNamespace, definition);
                if (definition is Struct)
                {
                    type.IsStruct = true;
                }
                else if (definition is IntegerEnum)
                {
                    type.IsEnum = true;
                }
                LOG.Debug(string.Format("Registering type '{0}'", type));
                _documentContext.TypeRegistry.Add(type);
            }
        }

        public void Visit(Header header)
        {
            throw new NotImplementedException();
        }

        public void Visit(IdentifierType identifierType)
        {
            throw new NotImplementedException();
        }

        public void Visit(IntegerEnum integerEnum)
        {
            throw new NotImplementedException();
        }

        public void Visit(IntegerEnumField integerEnumField)
        {
            throw new NotImplementedException();
        }

        public void Visit(ListType listType)
        {
            throw new NotImplementedException();
        }

        public void Visit(MapType mapType)
        {
            throw new NotImplementedException();
        }

        public void Visit(Service service)
        {
            throw new NotImplementedException();
        }

        public void Visit(Struct @struct)
        {
            throw new NotImplementedException();
        }

        public void Visit(BaijiField field)
        {
            throw new NotImplementedException();
        }

        public void Visit(BaijiMethod method)
        {
            throw new NotImplementedException();
        }

        public virtual CodeType CreateCodeType(string idlNamespace, string idlName, string name, string codeNamespace, Definition definition)
        {
            return new CodeType(idlNamespace, idlName, _documentContext.TypeMangler.MangleTypeName(name), codeNamespace, definition);
        }
    }
}