using System;
using System.Collections.Generic;
using System.Linq;
using CTripOSS.Baiji.Helper;
using CTripOSS.Baiji.IDLParser.Model;
using Irony.Parsing;

namespace CTripOSS.Baiji.IDLParser
{
    /// <summary>
    /// Build idl model by traversing CST (Concrete Syntax Tree).
    /// </summary>
    public static class DocumentBuilder
    {
        public static Document BuildDocument(ParseTreeNode documentNode)
        {
            Enforce.IsNotNull(documentNode, "document");
            var childNodes = documentNode.ChildNodes;
            if (childNodes == null || childNodes.Count == 0)
            {
                throw new ArgumentException("no child nodes on root of the document");
            }
            Header header = null;
            List<Definition> definitions = null;
            foreach (var childNode in childNodes)
            {
                if (childNode.Term.Name == IdlGrammar.NTNAME_HEADERS &&
                    childNode.ChildNodes != null && childNode.ChildNodes.Count > 0)
                {
                    header = BuildHeaders(childNode.ChildNodes);
                }
                else if (childNode.Term.Name == IdlGrammar.NTNAME_DEFINITIONS &&
                         childNode.ChildNodes != null && childNode.ChildNodes.Count > 0)
                {
                    definitions = BuildDefinitions(childNode.ChildNodes);
                }
            }
            return new Document(header, definitions);
        }

        public static Header BuildHeaders(ParseTreeNodeList headerNodes)
        {
            var includes = new List<string>();
            var namespaces = new Dictionary<string, string>();
            string defaultNamespace = null;
            foreach (var headerNode in headerNodes)
            {
                var headerChildNode = headerNode.ChildNodes[0];
                if (headerChildNode.Term.Name == IdlGrammar.NTNAME_TINCLUDE)
                {
                    var include = headerChildNode.FindTokenAndGetText();
                    include = RemoveQuote(include);
                    includes.Add(include);
                }
                else if (headerChildNode.Term.Name == IdlGrammar.NTNAME_TNAMESPACE)
                {
                    string scope = null;
                    string value = null;
                    foreach (var namespaceNode in headerChildNode.ChildNodes)
                    {
                        if (namespaceNode.Term.Name == IdlGrammar.NTNAME_TNAMESPACE_SCOPE)
                        {
                            scope = namespaceNode.FindTokenAndGetText();
                        }
                        else if (namespaceNode.Term.Name == IdlGrammar.NTNAME_NAMESPACE_VALUE)
                        {
                            value = namespaceNode.FindTokenAndGetText();
                            value = RemoveQuote(value);
                        }
                    }
                    if (scope == "*")
                    {
                        defaultNamespace = value;
                    }
                    else
                    {
                        namespaces.Add(scope, value);
                    }
                }
            }

            return new Header(includes, defaultNamespace, namespaces);
        }

        // remove " or '
        private static string RemoveQuote(string value)
        {
            if (value == null)
            {
                return null;
            }
            var length = value.Length;
            if (value.StartsWith("\"") && value.EndsWith("\""))
            {
                return value.Substring(1, length - 2);
            }
            if (value.StartsWith("'") && value.EndsWith("'"))
            {
                return value.Substring(1, length - 2);
            }
            return value;
        }

        public static List<Definition> BuildDefinitions(ParseTreeNodeList definitionNodes)
        {
            var definitions = new List<Definition>();
            foreach (var definitionNode in definitionNodes)
            {
                var definitionChildNode = definitionNode.ChildNodes[0];

                if (definitionChildNode.Term.Name == IdlGrammar.CNAME_DOC_STRING)
                {
                    continue;
                }

                string[] docStringLines = null;
                IList<Annotation> annotations = null;
                var docStringNode = definitionChildNode.ChildNodes[0];
                if (docStringNode.ChildNodes.Count != 0)
                {
                    docStringLines = ParseDocStringLines(docStringNode.ChildNodes[0].Token.Text);
                }
                var annotationsNode = definitionChildNode.ChildNodes[1];
                if (annotationsNode.ChildNodes.Count != 0)
                {
                    annotations = BuildAnnotations(annotationsNode.ChildNodes);
                }

                if (definitionChildNode.Term.Name == IdlGrammar.NTNAME_TENUM)
                {
                    var enumId = definitionChildNode.ChildNodes[2].Token.Text;
                    var enumFields = new List<IntegerEnumField>();
                    int nextDefaultEnumValue = 0; // enumerations start at zero by default
                    foreach (var enumFieldNode in definitionChildNode.ChildNodes[3].ChildNodes)
                    {
                        string[] fieldDocStringLines = null;
                        var fieldDocStringNode = enumFieldNode.ChildNodes[0];
                        if (fieldDocStringNode.ChildNodes.Count != 0)
                        {
                            fieldDocStringLines = ParseDocStringLines(fieldDocStringNode.ChildNodes[0].Token.Text);
                        }
                        var enumFieldId = enumFieldNode.ChildNodes[1].Token.Text;
                        IntegerEnumField enumField;
                        if (enumFieldNode.ChildNodes.Count > 1 &&
                            enumFieldNode.ChildNodes[2].ChildNodes != null &&
                            enumFieldNode.ChildNodes[2].ChildNodes.Count > 0) // has enum value
                        {
                            var valueText = enumFieldNode.ChildNodes[2].ChildNodes[0].Token.Text;
                            int enumValue = int.Parse(valueText);
                            enumField = new IntegerEnumField(fieldDocStringLines, enumFieldId, enumValue,
                                nextDefaultEnumValue);
                            nextDefaultEnumValue = ++enumValue;
                        }
                        else
                        {
                            enumField = new IntegerEnumField(fieldDocStringLines, enumFieldId, null,
                                nextDefaultEnumValue);
                            ++nextDefaultEnumValue;
                        }
                        enumFields.Add(enumField);
                    }
                    var integerEnum = new IntegerEnum(docStringLines, enumId, enumFields, annotations);
                    definitions.Add(integerEnum);
                }
                else if (definitionChildNode.Term.Name == IdlGrammar.NTNAME_TSTRUCT)
                {
                    var name = definitionChildNode.ChildNodes[2].Token.Text;
                    var fields = BuildFields(definitionChildNode.ChildNodes[3], name);
                    var @struct = new Struct(docStringLines, name, fields, annotations);
                    definitions.Add(@struct);
                }
                else if (definitionChildNode.Term.Name == IdlGrammar.NTNAME_TSERVICE)
                {
                    var name = definitionChildNode.ChildNodes[2].Token.Text;
                    IList<BaijiMethod> methods = new List<BaijiMethod>();

                    var functionsChild = definitionChildNode.ChildNodes[3];
                    if (functionsChild.Term.Name == IdlGrammar.NTNAME_FUNCTIONS)
                    {
                        methods = BuildMethods(functionsChild);
                    }

                    var service = new Service(docStringLines, name, methods, annotations);
                    definitions.Add(service);
                }
            }

            var structs = definitions.OfType<Struct>().ToList();

            // Mark some flags in structs
            foreach (var @struct in structs)
            {
                foreach (var field in @struct.Fields)
                {
                    var name = field.Name.ToLower();
                    if (!(field.Type is IdentifierType))
                    {
                        continue;
                    }
                    var pureType = ((IdentifierType)field.Type).Name.Split('.').Last();
                    switch (name)
                    {
                        case "head":
                            if (pureType.EndsWith("MobileRequestHead"))
                            {
                                @struct.HasMobileRequestHead = true;
                            }
                            break;
                        case "responsestatus":
                            if (pureType.EndsWith("ResponseStatusType"))
                            {
                                @struct.HasResponseStatus = true;
                            }
                            break;
                    }
                }
            }

            // Mark all locally referenced response struct types.
            foreach (var service in definitions.OfType<Service>())
            {
                foreach (var method in service.Methods)
                {
                    var responseStruct = structs.FirstOrDefault(s => s.Name == method.ReturnType.Name);
                    if (responseStruct != null)
                    {
                        responseStruct.IsServiceResponse = true;
                    }
                }
            }

            return definitions;
        }

        public static IList<BaijiMethod> BuildMethods(ParseTreeNode methodNodes)
        {
            List<BaijiMethod> methods = new List<BaijiMethod>();
            foreach (var methodNode in methodNodes.ChildNodes)
            {
                string[] docStringLines = null;
                var docStringNode = methodNode.ChildNodes[0];
                if (docStringNode.ChildNodes.Count != 0)
                {
                    docStringLines = ParseDocStringLines(docStringNode.ChildNodes[0].Token.Text);
                }
                IdentifierType returnType = new IdentifierType(methodNode.ChildNodes[1].Token.Text);
                string name = methodNode.ChildNodes[2].Token.Text;
                IdentifierType argumentType = new IdentifierType(methodNode.ChildNodes[3].Token.Text);
                string argumentName = methodNode.ChildNodes[4].Token.Text;
                var method = new BaijiMethod(docStringLines, name, returnType, argumentType, argumentName);
                methods.Add(method);
            }

            return methods;
        }

        public static List<BaijiField> BuildFields(ParseTreeNode fieldNodes, string structName)
        {
            var fields = new List<BaijiField>();
            foreach (var fieldNode in fieldNodes.ChildNodes)
            {
                string[] docStringLines = null;
                string fieldName = null;
                Required fieldReq = Required.NONE;
                BaijiType fieldType = null;
                IList<Annotation> annotations = null;
                foreach (var fieldChildNode in fieldNode.ChildNodes)
                {
                    if (fieldChildNode.Term.Name == IdlGrammar.NTNAME_TDOCSTRINGOREMPTY &&
                        fieldChildNode.ChildNodes.Count > 0)
                    {
                        docStringLines = ParseDocStringLines(fieldChildNode.ChildNodes[0].FindTokenAndGetText());
                    }
                    else if (fieldChildNode.Term.Name == IdlGrammar.NTNAME_FIELD_REQ &&
                             fieldChildNode.ChildNodes.Count > 0)
                    {
                        var fieldReqText = fieldChildNode.ChildNodes[0].FindTokenAndGetText();
                        if (fieldReqText == "required")
                        {
                            fieldReq = Required.REQUIRED;
                        }
                        else if (fieldReqText == "optional")
                        {
                            fieldReq = Required.OPTIONAL;
                        }
                        else
                        {
                            fieldReq = Required.NONE;
                        }
                    }
                    else if (fieldChildNode.Term.Name == IdlGrammar.NTNAME_TFIELD_TYPE)
                    {
                        fieldType = BuildFieldType(fieldChildNode);
                    }
                    else if (fieldChildNode.Term.Name == IdlGrammar.TNAME_TIDENTIFIER)
                    {
                        fieldName = fieldChildNode.Token.Text;
                    }
                    else if (fieldChildNode.Term.Name == IdlGrammar.NTNAME_TANNOTATIONSOREMPTY
                             && fieldChildNode.ChildNodes.Count > 0)
                    {
                        annotations = BuildAnnotations(fieldChildNode.ChildNodes);
                    }
                }

                var field = new BaijiField(docStringLines, fieldName, fieldType, fieldReq, annotations);
                fields.Add(field);
            }

            return fields;
        }

        public static BaijiType BuildMapKeyType(ParseTreeNode mapKeyTypeNode)
        {
            var baseTypeKeyword = mapKeyTypeNode.FindTokenAndGetText();
            var bType = ConvertBaseTypeKeywordToBaseType(baseTypeKeyword);
            var type = new BaseType(bType);
            return type;
        }

        public static BaijiType BuildFieldType(ParseTreeNode fieldTypeNode)
        {
            BaijiType type = null;

            var fieldTypeChildNode = fieldTypeNode.ChildNodes[0];

            if (fieldTypeChildNode.Term.Name == IdlGrammar.TNAME_TIDENTIFIER)
            {
                var identifier = fieldTypeChildNode.Token.Text;
                type = new IdentifierType(identifier);
            }
            else if (fieldTypeChildNode.Term.Name == IdlGrammar.NTNAME_TBASE_TYPE)
            {
                var baseTypeKeyword = fieldTypeChildNode.FindTokenAndGetText();
                var bType = ConvertBaseTypeKeywordToBaseType(baseTypeKeyword);
                type = new BaseType(bType);
            }
            else if (fieldTypeChildNode.Term.Name == IdlGrammar.NTNAME_TCONTAINER_TYPE)
            {
                var containerTypeNode = fieldTypeChildNode.ChildNodes[0];
                if (containerTypeNode.Term.Name == IdlGrammar.NTNAME_TMAP_TYPE)
                {
                    var keyType = BuildMapKeyType(containerTypeNode.ChildNodes[0]);
                    var valueType = BuildFieldType(containerTypeNode.ChildNodes[1]);
                    type = new MapType(keyType, valueType);
                }
                else if (containerTypeNode.Term.Name == IdlGrammar.NTNAME_TLIST_TYPE)
                {
                    var listValueType = BuildFieldType(containerTypeNode.ChildNodes[0]);
                    type = new ListType(listValueType);
                }
            }

            return type;
        }

        private static IList<Annotation> BuildAnnotations(ParseTreeNodeList nodes)
        {
            var annotations = new List<Annotation>(nodes.Count);
            foreach (var node in nodes)
            {
                var name = node.ChildNodes[0].FindTokenAndGetText();
                var valueToken = node.ChildNodes[1].FindToken();
                var value = valueToken != null ? valueToken.ValueString : null;
                var annotation = new Annotation(name, value);
                annotations.Add(annotation);
            }
            return annotations;
        }

        public static BType ConvertBaseTypeKeywordToBaseType(string keyword)
        {
            if (keyword == "bool")
            {
                return BType.BOOL;
            }
            if (keyword == "int")
            {
                return BType.I32;
            }
            if (keyword == "long")
            {
                return BType.I64;
            }
            if (keyword == "double")
            {
                return BType.DOUBLE;
            }
            if (keyword == "string")
            {
                return BType.STRING;
            }
            if (keyword == "binary")
            {
                return BType.BINARY;
            }
            if (keyword == "datetime")
            {
                return BType.DATETIME;
            }
            if (keyword == "string")
            {
                return BType.STRING;
            }
            return (BType)255;
        }

        private static string[] ParseDocStringLines(string docStringText)
        {
            if (string.IsNullOrEmpty(docStringText))
            {
                return null;
            }
            var lines = docStringText.Substring(2, docStringText.Length - 4) // Remove "/*" and "*/"
                .Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            for (var i = 0; i < lines.Length; ++i)
            {
                lines[i] = lines[i].Trim();
            }

            // Remove leading and trailing blank lines.
            int leadingBlankCount = 0, lastNonBlankIndex = lines.Length - 1;
            for (; string.IsNullOrEmpty(lines[leadingBlankCount]); ++leadingBlankCount)
            {
            }
            for (; string.IsNullOrEmpty(lines[lastNonBlankIndex]); --lastNonBlankIndex)
            {
            }

            return lines.Skip(leadingBlankCount)
                .Take(lastNonBlankIndex - leadingBlankCount + 1).ToArray();
        }
    }
}