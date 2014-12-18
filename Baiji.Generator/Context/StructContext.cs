using System.Collections.Generic;
using System.Text;
using CTripOSS.Baiji.Helper;

namespace CTripOSS.Baiji.Generator.Context
{
    public class StructContext : CodeContext
    {
        private readonly string _schemaText;

        public StructContext(string[] docStringLines, string idlName, string @namespace, string codeName,
            bool isServiceResponse, bool hasResponseStatus, bool hasMobileRequestHead, string schemaText,
            int indentLevel)
        {
            DocStringLines = docStringLines;
            Name = idlName;
            Namespace = @namespace;
            TypeName = codeName;
            Fields = new List<FieldContext>();
            IsServiceResponse = isServiceResponse;
            HasResponseStatus = hasResponseStatus;
            HasMobileRequestHead = hasMobileRequestHead;
            _schemaText = schemaText;
            IndentLevel = indentLevel;
        }

        public List<FieldContext> Fields
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

        public string Name
        {
            get;
            private set;
        }

        public string TypeName
        {
            get;
            private set;
        }

        public bool IsServiceResponse
        {
            get;
            private set;
        }

        public bool HasResponseStatus
        {
            get;
            private set;
        }

        public bool HasMobileRequestHead
        {
            get;
            private set;
        }

        public void AddField(FieldContext field)
        {
            Fields.Add(field);
        }

        protected void IndentUp()
        {
            IndentLevel++;
        }

        protected void IndentDown()
        {
            IndentLevel--;
        }

        protected void ScopeUp(StringBuilder sb)
        {
            sb.Indent(IndentLevel).AppendLine("{");
            IndentLevel++;
        }

        protected void ScopeDown(StringBuilder sb)
        {
            IndentLevel--;
            sb.Indent(IndentLevel).AppendLine("}");
        }

        public string SchemaText
        {
            get
            {
                return _schemaText;
            }
        }

        public virtual string EscapedSchemaText
        {
            get
            {
                return _schemaText.Replace("\"", "\\\"");
            }
        }

        protected int IndentLevel
        {
            get;
            private set;
        }
    }
}