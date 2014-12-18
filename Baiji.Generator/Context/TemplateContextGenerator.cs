using System;
using System.Collections.Generic;
using System.Linq;
using CTripOSS.Baiji.IDLParser.Model;

namespace CTripOSS.Baiji.Generator.Context
{
    public abstract class TemplateContextGenerator
    {
        protected readonly GeneratorConfig _generatorConfig;
        protected readonly TypeRegistry _typeRegistry;
        protected readonly TypeConverter _typeConverter;
        protected readonly ITypeMangler _typeMangler;
        protected readonly SchemaBuilder _schemaBuilder;
        protected readonly string _defaultNamespace;

        protected TemplateContextGenerator(GeneratorConfig generatorConfig,
            TypeRegistry typeRegistry,
            TypeConverter typeConverter,
            ITypeMangler typeMangler,
            string defaultNamespace)
        {
            _generatorConfig = generatorConfig;
            _typeRegistry = typeRegistry;
            _typeConverter = typeConverter;
            _typeMangler = typeMangler;
            _defaultNamespace = defaultNamespace;
            _schemaBuilder = new SchemaBuilder(_typeConverter, _typeMangler);
        }

        public virtual ServiceContext ServiceFromIdl(Service service)
        {
            ValidateService(service);

            var name = _typeMangler.MangleTypeName(service.Name);
            var type = _typeRegistry.FindType(_defaultNamespace, name);

            var parents = new HashSet<string>();

            string serviceName, serviceNamespace;
            GetServiceNameAndNamespace(service, out serviceName, out serviceNamespace);

            var serviceContext = new ServiceContext(service.DocStringLines, name, type.CodeNamespace, type.Name,
                parents, serviceName, serviceNamespace);
            foreach (var method in service.Methods)
            {
                var methodContext = MethodFromIdl(method);
                serviceContext.AddMethod(methodContext);
            }
            return serviceContext;
        }

        public ClientContext ClientFromIdl(Service service)
        {
            ValidateService(service);

            var name = _typeMangler.MangleClientName(service.Name);
            var type = _typeRegistry.FindType(_defaultNamespace, service.Name);

            var csharpParents = new HashSet<string>();
            string serviceName, serviceNamespace;
            GetServiceNameAndNamespace(service, out serviceName, out serviceNamespace);

            var clientContext = new ClientContext(service.DocStringLines, name, type.CodeNamespace,
                                                  name, csharpParents, serviceName, serviceNamespace);
            foreach (var method in service.Methods)
            {
                var methodContext = MethodFromIdl(method);
                clientContext.AddMethod(methodContext);
            }
            return clientContext;
        }

        private void ValidateService(Service service)
        {
            var methodNames = new Dictionary<string, string>();
            var duplicatedMethods = new List<string>();
            foreach (var method in service.Methods)
            {
                var normalizedName = method.Name.ToLower();
                if (methodNames.ContainsKey(normalizedName))
                {
                    duplicatedMethods.Add(methodNames[normalizedName]);
                    continue;
                }
                methodNames.Add(normalizedName, method.Name);
            }
            if (duplicatedMethods.Count != 0)
            {
                var message = string.Format("Service {0} has duplicated operation(s): {1}. Operation names are case insensitive. Please fix them and try again.",
                    service.Name, string.Join(",", duplicatedMethods));
                throw new ArgumentException(message);
            }
        }

        private void GetServiceNameAndNamespace(Service service, out string serviceName, out string serviceNamespace)
        {
            serviceName = serviceNamespace = null;
            if (service.Annotations != null && service.Annotations.Count != 0)
            {
                var serviceNameAnnotation = service.Annotations.FirstOrDefault(a => a.Name == "serviceName");
                serviceName = serviceNameAnnotation != null ? serviceNameAnnotation.Value : null;
                var serviceNamespaceAnnotation = service.Annotations.FirstOrDefault(a => a.Name == "serviceNamespace");
                serviceNamespace = serviceNamespaceAnnotation != null ? serviceNamespaceAnnotation.Value : null;
            }
            if (serviceName == null || serviceNamespace == null)
            {
                var message = string.Format("serviceName and serviceNamespace annotations are required for {0}.",
                                            service.Name);
                throw new ArgumentException(message);
            }
        }

        public virtual StructContext StructFromIdl(Struct @struct)
        {
            ValidateStruct(@struct);

            var name = _typeMangler.MangleTypeName(@struct.Name);
            var type = _typeRegistry.FindType(_defaultNamespace, name);
            var schemaText = _schemaBuilder.Build(type);
            var structContext = new StructContext(@struct.DocStringLines, name, type.CodeNamespace, type.Name,
                @struct.IsServiceResponse, @struct.HasResponseStatus, @struct.HasMobileRequestHead, schemaText, 0);
            foreach (var field in @struct.Fields)
            {
                structContext.AddField(FieldFromIdl(field));
            }
            return structContext;
        }

        private void ValidateStruct(Struct @struct)
        {
            var fieldNames = new Dictionary<string, string>();
            var duplicatedFields = new List<string>();
            foreach (var field in @struct.Fields)
            {
                var normalizedName = field.Name.ToLower();
                if (fieldNames.ContainsKey(normalizedName))
                {
                    duplicatedFields.Add(fieldNames[normalizedName]);
                    continue;
                }
                fieldNames.Add(normalizedName, field.Name);
            }
            if (duplicatedFields.Count != 0)
            {
                var message = string.Format("Class {0} has duplicated field(s): {1}. Field names are case insensitive. Please fix them and try again.",
                    @struct.Name, string.Join(",", duplicatedFields));
                throw new ArgumentException(message);
            }
        }

        public virtual MethodContext MethodFromIdl(BaijiMethod method)
        {
            if (!_typeConverter.IsStructIdentifier(method.ReturnType))
            {
                throw new ArgumentException(
                    string.Format("Return type of method must be a struct type, method {0}, return type {1}.",
                        method.Name, method.ReturnType.Name));
            }
            if (!_typeConverter.IsStructIdentifier(method.ArgumentType))
            {
                throw new ArgumentException(
                    string.Format("Argument type of method must be a struct type, method {0}, argument type {1}.",
                        method.Name, method.ArgumentType.Name));
            }

            return new MethodContext(method.DocStringLines, method.Name, false,
                _typeMangler.MangleMethodName(method.Name),
                _typeConverter.ConvertToString(method.ReturnType),
                _typeMangler.MangleArgumentName(method.ArgumentName),
                _typeConverter.ConvertToString(method.ArgumentType));
        }

        public virtual FieldContext FieldFromIdl(BaijiField field)
        {
            var context = new FieldContext(field.DocStringLines,
                field.Name,
                _typeMangler.MangleFieldName(field.Name),
                field.Required == Required.REQUIRED,
                _typeConverter.ConvertToGenType(field.Type));
            return context;
        }

        public virtual EnumContext EnumFromIdl(IntegerEnum integerEnum)
        {
            var name = _typeMangler.MangleTypeName(integerEnum.Name);
            var type = _typeRegistry.FindType(_defaultNamespace, name);
            return new EnumContext(integerEnum.DocStringLines, type.CodeNamespace, type.Name);
        }

        public virtual EnumFieldContext FieldFromIdl(IntegerEnumField field)
        {
            return new EnumFieldContext(field.DocStringLines, field.Name, field.Value);
        }
    }
}