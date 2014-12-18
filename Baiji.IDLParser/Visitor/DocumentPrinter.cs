using System;
using System.Text;
using CTripOSS.Baiji.IDLParser.Model;

namespace CTripOSS.Baiji.IDLParser.Visitor
{
    public class DocumentPrinter : IVisitor
    {
        private StringBuilder sb = new StringBuilder();

        public String DocumentText
        {
            get
            {
                return sb.ToString();
            }
        }

        private void VisitType(BaijiType type)
        {
            if (type is IdentifierType)
            {
                Visit((IdentifierType)type);
            }
            else if (type is BaseType)
            {
                Visit((BaseType)type);
            }
            else if (type is ListType)
            {
                Visit((ListType)type);
            }
            else if (type is MapType)
            {
                Visit((MapType)type);
            }
        }

        public void Visit(BaseType baseType)
        {
            sb.Append(baseType.BType.ToString().ToLower());
        }

        public void Visit(Document document)
        {
            sb = new StringBuilder();
            sb.AppendLine("IDL Document : ");
            sb.AppendLine("IDL Headers : ");
            sb.AppendLine();
            if (document.Header != null)
            {
                Visit(document.Header);
            }
            sb.AppendLine();
            sb.AppendLine("IDL Definitions : ");
            sb.AppendLine();
            foreach (var definition in document.Definitions)
            {
                if (definition is Struct)
                {
                    Visit((Struct)definition);
                    sb.AppendLine();
                }
                else if (definition is IntegerEnum)
                {
                    Visit((IntegerEnum)definition);
                    sb.AppendLine();
                }
                else if (definition is Service)
                {
                    Visit((Service)definition);
                    sb.AppendLine();
                }
            }
        }

        public void Visit(Header header)
        {
            foreach (string include in header.Includes)
            {
                sb.Append("Include : ").AppendLine(include);
            }
            if (!string.IsNullOrEmpty(header.DefaultNamespace))
            {
                sb.Append("Default namespace : ").AppendLine(header.DefaultNamespace);
            }
            foreach (string nsScope in header.Namespaces.Keys)
            {
                sb.Append("Namespace ").Append(nsScope).Append(" ").AppendLine(header.Namespaces[nsScope]);
            }
        }

        public void Visit(IdentifierType identifierType)
        {
            sb.Append(identifierType.Name);
        }

        public void Visit(IntegerEnum integerEnum)
        {
            sb.Append("Enum ").Append(integerEnum.Name);
            sb.AppendLine(" {");
            foreach (var enumField in integerEnum.Fields)
            {
                Visit(enumField);
                sb.AppendLine();
            }
            sb.AppendLine("}");
        }

        public void Visit(IntegerEnumField integerEnumField)
        {
            sb.Append("  ");
            sb.Append(integerEnumField.Name);
            sb.Append(" : ");
            sb.Append(integerEnumField.Value);
        }

        public void Visit(ListType listType)
        {
            sb.Append("list").Append("<");
            VisitType(listType.Type);
            sb.Append(">");
        }

        public void Visit(MapType mapType)
        {
            sb.Append("map").Append("<");
            VisitType(mapType.KeyType);
            sb.Append(",");
            VisitType(mapType.ValueType);
            sb.Append(">");
        }

        public void Visit(Service service)
        {
            AppendDocStringLines(service.DocStringLines);
            sb.Append("Service ").Append(service.Name);
            sb.AppendLine(" {");

            foreach (var method in service.Methods)
            {
                Visit(method);
                sb.AppendLine();
            }
            sb.AppendLine("}");
        }

        public void Visit(Struct _struct)
        {
            AppendDocStringLines(_struct.DocStringLines);
            sb.Append("Struct ").Append(_struct.Name).AppendLine(" {");
            int count = _struct.Fields.Count;
            foreach (var field in _struct.Fields)
            {
                sb.Append("  "); // ident
                Visit(field);
                if (count > 1)
                {
                    sb.AppendLine(";");
                }
                count--;
            }
            sb.AppendLine().AppendLine("}");
        }

        public void Visit(BaijiField field)
        {
            AppendDocStringLines(field.DocStringLines);
            if (field.Required != Required.NONE)
            {
                sb.Append(field.Required.ToString().ToLower()).Append(" ");
            }
            VisitType(field.Type);
            sb.Append(" ").Append(field.Name).Append(" ");
        }

        public void Visit(BaijiMethod method)
        {
            AppendDocStringLines(method.DocStringLines);
            sb.Append("  "); // identation
            VisitType(method.ReturnType);
            sb.Append(" ").Append(method.Name).Append("(");
            VisitType(method.ArgumentType);
            sb.Append(" ").Append(method.ArgumentName);
            sb.Append(") ");
        }

        private void AppendDocStringLines(string[] docStringLines)
        {
            if (docStringLines == null || docStringLines.Length == 0)
            {
                return;
            }
            sb.Append("'''");
            for (var i = 0; i < docStringLines.Length - 1; ++i)
            {
                sb.AppendLine(docStringLines[i]);
            }
            sb.Append(docStringLines[docStringLines.Length - 1]);
            sb.AppendLine("'''");
        }
    }
}