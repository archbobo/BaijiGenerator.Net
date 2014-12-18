using Irony.Parsing;

namespace CTripOSS.Baiji.IDLParser
{
    /// <summary>
    /// This class defines the Grammar for the Baiji IDL,
    /// adapted thrift idl here : http://thrift.apache.org/docs/idl/
    /// </summary>
    [Language("BaijiIdlParser", "1.1", "Grammar for the Baiji IDL")]
    public class IdlGrammar : Grammar
    {
        // non-terminal names
        public const string NTNAME_TDOCUMENT = "TDocument";
        public const string NTNAME_THEADER = "THeader";
        public const string NTNAME_HEADERS = "Headers";
        public const string NTNAME_DEFINITIONS = "Definitions";
        public const string NTNAME_TINCLUDE = "TInclude";
        public const string NTNAME_INCLUDE_VALUE = "IncludeValue";
        public const string NTNAME_TNAMESPACE = "TNamespace";
        public const string NTNAME_TNAMESPACE_SCOPE = "TNamespaceScope";
        public const string NTNAME_NAMESPACE_VALUE = "NamespaceValue";
        public const string NTNAME_TDEFINITION = "TDefinition";
        public const string NTNAME_TFIELD_TYPE = "TFieldType";
        public const string NTNAME_TMAP_KEY_TYPE = "TMapKeyType";
        public const string NTNAME_TMAP_TYPE = "TMapType";
        public const string NTNAME_TLIST_TYPE = "TListType";
        public const string NTNAME_TNONCONTAINER_TYPE = "TNonContainerType";
        public const string NTNAME_TCONTAINER_TYPE = "TContainerType";
        public const string NTNAME_TBASE_TYPE = "TBaseType";
        public const string NTNAME_TENUM = "TEnum";
        public const string NTNAME_ENUM_FIELDS = "EnumFields";
        public const string NTNAME_ENUM_FIELD = "EnumField";
        public const string NTNAME_ENUM_VALUE = "EnumValue";
        public const string NTNAME_TSTRUCT = "TStruct";
        public const string NTNAME_TFIELD = "TField";
        public const string NTNAME_TFIELD_REQ = "TFieldReq";
        public const string NTNAME_FIELD_REQ = "FieldReq";
        public const string NTNAME_STRUCT_FIELDS = "StructFields";
        public const string NTNAME_TSERVICE = "TService";
        public const string NTNAME_TFUNCTION = "TFunction";
        public const string NTNAME_FUNCTIONS = "Functions";
        public const string NTNAME_TDOCSTRINGOREMPTY = "TDocStringOrEmpty";
        public const string NTNAME_TANNOTATION = "TAnnotation";
        public const string NTNAME_TANNOTATIONSOREMPTY = "TAnnotationsOrEmpty";

        // terminal names
        public const string TNAME_TIDENTIFIER = "TIdentifier";
        public const string TNAME_TSINGLE_QUOTE_LITERAL = "TSingleQuoteLiteral";
        public const string TNAME_TDOUBLE_QUOTE_LITERAL = "TDoubleQuoteLiteral";

        // comment names
        public const string CNAME_WELL_LINE_COMMENT = "WELL_LINE_COMMENT";
        public const string CNAME_SLASH_LINE_COMMENT = "SLASH_LINE_COMMENT";
        public const string CNAME_DOC_STRING = "DOC_STRING";

        public IdlGrammar()
        {
            #region Initial setup of the grammar

            // 1. define all the non-terminals
            var tDocument = new NonTerminal(NTNAME_TDOCUMENT);
            var tHeader = new NonTerminal(NTNAME_THEADER);
            var tInclude = new NonTerminal(NTNAME_TINCLUDE);
            var tNamespace = new NonTerminal(NTNAME_TNAMESPACE);
            var tNamespaceScope = new NonTerminal(NTNAME_TNAMESPACE_SCOPE);
            var tDefinition = new NonTerminal(NTNAME_TDEFINITION);
            var tEnum = new NonTerminal(NTNAME_TENUM);
            var tStruct = new NonTerminal(NTNAME_TSTRUCT);
            var tService = new NonTerminal(NTNAME_TSERVICE);
            var tField = new NonTerminal(NTNAME_TFIELD);
            var tFieldReq = new NonTerminal(NTNAME_TFIELD_REQ);
            var tFunction = new NonTerminal(NTNAME_TFUNCTION);
            var tFieldType = new NonTerminal(NTNAME_TFIELD_TYPE);
            var tBaseType = new NonTerminal(NTNAME_TBASE_TYPE);
            var tNonContainerType = new NonTerminal(NTNAME_TNONCONTAINER_TYPE);
            var tContainerType = new NonTerminal(NTNAME_TCONTAINER_TYPE);
            var tMapKeyType = new NonTerminal(NTNAME_TMAP_KEY_TYPE);
            var tMapType = new NonTerminal(NTNAME_TMAP_TYPE);
            var tListType = new NonTerminal(NTNAME_TLIST_TYPE);
            var tListSeparator = new NonTerminal("TListSeparator");
            var tDocStringOrEmpty = new NonTerminal(NTNAME_TDOCSTRINGOREMPTY);
            var tAnnotation = new NonTerminal(NTNAME_TANNOTATION);
            var tAnnotationsOrEmpty = new NonTerminal(NTNAME_TANNOTATIONSOREMPTY);

            // 2. define all the terminals
            var tSingleQuoteLiteral = new StringLiteral(TNAME_TSINGLE_QUOTE_LITERAL, "\'");
            var tDoubleQuoteLiteral = new StringLiteral(TNAME_TDOUBLE_QUOTE_LITERAL, "\"");
            // Identifier      ::=  ( Letter | '_' ) ( Letter | Digit | '.' | '_' )*
            var tIdentifier = new IdentifierTerminal(TNAME_TIDENTIFIER, "._", "_");
            var tIntNumber = new NumberLiteral("TIntNumber", NumberOptions.AllowSign | NumberOptions.IntOnly);

            CommentTerminal WELL_LINE_COMMENT = new CommentTerminal(CNAME_WELL_LINE_COMMENT, "#", "\n", "\r\n");
            CommentTerminal SLASH_LINE_COMMENT = new CommentTerminal(CNAME_SLASH_LINE_COMMENT, "//", "\n", "\r\n");
            CommentTerminal DOC_STRING = new CommentTerminal(CNAME_DOC_STRING, "/*", "*/");
            NonGrammarTerminals.Add(WELL_LINE_COMMENT);
            NonGrammarTerminals.Add(SLASH_LINE_COMMENT);

            #endregion

            #region Define the grammar

            // 3. define BNF rules

            // Prepare rule for future use
            tDocStringOrEmpty.Rule = DOC_STRING | Empty;
            var literal = (tSingleQuoteLiteral | tDoubleQuoteLiteral);
            tAnnotation.Rule = "@" + tIdentifier + (("=" + literal) | Empty);
            tAnnotationsOrEmpty.Rule = MakeStarRule(tAnnotationsOrEmpty, tAnnotation);

            // Document ::= Header* Definition*
            var headers = new NonTerminal(NTNAME_HEADERS);
            var definitions = new NonTerminal(NTNAME_DEFINITIONS);
            headers.Rule = MakeStarRule(headers, tHeader);
            definitions.Rule = MakeStarRule(definitions, tDefinition);
            tDocument.Rule = headers + definitions;
            // Header ::= Include | Namespace
            // Not to include DOC_STRING in header to fix the issue
            // that the initial DOC_STRING in definition is mis-included in the header.
            tHeader.Rule = tInclude | tNamespace;
            // Include ::= 'include' Literal
            var includeValue = new NonTerminal(NTNAME_INCLUDE_VALUE);
            includeValue.Rule = (tSingleQuoteLiteral | tDoubleQuoteLiteral);
            tInclude.Rule = "include" + includeValue;
            // Namespace ::= 'namespace' NamespaceScope Identifier
            var namespaceValue = new NonTerminal(NTNAME_NAMESPACE_VALUE);
            namespaceValue.Rule = tIdentifier | literal;
            tNamespace.Rule = "namespace" + tNamespaceScope + namespaceValue;
            // NamespaceScope ::= 'java' | 'csharp' | 'objc'
            tNamespaceScope.Rule = ToTerm("java") | "csharp" | "objc" | tIdentifier;
            // Definition ::= Enum | Struct | Service | DOC_STRING
            // Adding DOC_STRING here is to make it recognizable right after it's finished,
            // no need to wait until the whole definition (e.g. a struct) is finished.
            tDefinition.Rule = tEnum | tStruct | tService | DOC_STRING;
            var listSeparatorOrEmpty = new NonTerminal("ListSeparatorOrEmpty");
            listSeparatorOrEmpty.Rule = tListSeparator | Empty;
            // Enum ::= 'enum' Identifier '{' (Identifier ('=' IntConstant)? ListSeparator?)* '}'
            var enumValue = new NonTerminal(NTNAME_ENUM_VALUE);
            // No explicit enum value is allowed for now.
            //enumValue.Rule = ("=" + tIntNumber) | Empty;
            enumValue.Rule = Empty;
            var enumField = new NonTerminal(NTNAME_ENUM_FIELD);
            enumField.Rule = tDocStringOrEmpty + tIdentifier + enumValue;
            var enumFields = new NonTerminal(NTNAME_ENUM_FIELDS);
            enumFields.Rule = MakeListRule(enumFields, tListSeparator, enumField, TermListOptions.StarList | TermListOptions.AllowTrailingDelimiter);
            tEnum.Rule = tDocStringOrEmpty + tAnnotationsOrEmpty + "enum" + tIdentifier + "{" + enumFields + "}";
            // Struct ::= 'class' Identifier '{' Field* '}'
            var structFields = new NonTerminal(NTNAME_STRUCT_FIELDS);
            structFields.Rule = MakeStarRule(structFields, null, tField);
            tStruct.Rule = tDocStringOrEmpty + tAnnotationsOrEmpty + "class" + tIdentifier + "{" + structFields + "}";
            // Service ::= 'service' Identifier '{' Function* '}'
            var functions = new NonTerminal(NTNAME_FUNCTIONS);
            functions.Rule = MakeStarRule(functions, null, tFunction);
            tService.Rule = tDocStringOrEmpty + tAnnotationsOrEmpty + "service" + tIdentifier + "{" + functions + "}";
            // Field ::= FieldID FieldReq? FieldType Identifier ('=' ConstValue)? ListSeparator?
            var fieldReq = new NonTerminal(NTNAME_FIELD_REQ);
            fieldReq.Rule = tFieldReq | Empty;
            tField.Rule = tDocStringOrEmpty + tAnnotationsOrEmpty + fieldReq + tFieldType + tIdentifier + listSeparatorOrEmpty;
            // FieldReq ::= 'required' | 'optional'
            tFieldReq.Rule = ToTerm("required") | "optional";
            // Function ::=  Identifier Identifier '(' Identifier Identifier ')' ListSeparator?
            tFunction.Rule = tDocStringOrEmpty + tIdentifier + tIdentifier + "(" + tIdentifier + tIdentifier + ")" + listSeparatorOrEmpty;
            // MapKeyType ::= 'string'
            tMapKeyType.Rule = ToTerm("string");
            // FieldType ::= Identifier | BaseType | ContainerType
            tFieldType.Rule = tIdentifier | tBaseType | tContainerType;
            // BaseType ::= 'bool' | 'int' | 'long' | 'double' | 'string' | 'binary' | 'datetime'
            tBaseType.Rule = ToTerm("bool") | "int" | "long" | "double" | "string" | "binary" | "datetime";
            // ContainerType ::= MapType | ListType
            tContainerType.Rule = tMapType | tListType;
            // NonContainerType ::= Identifier | BaseType
            tNonContainerType.Rule = tIdentifier | tBaseType;
            // MapType ::= 'map' '<' MapKeyType ',' FieldType '>'
            tMapType.Rule = ToTerm("map") + "<" + tMapKeyType + "," + tNonContainerType + ">";
            // ListType ::= 'list' '<' FieldType '>'
            tListType.Rule = ToTerm("list") + "<" + tNonContainerType + ">";
            // ListSeparator ::= ',' | ';'
            tListSeparator.Rule = ToTerm(",") | ";";

            #endregion

            // Set grammar root
            this.Root = tDocument;

            // 4. Punctuation and transient terms
            MarkPunctuation("include", "namespace", "=", "enum", "class", "{", "}", "(", ")",
                "service", "map", "set", "list", "<", ">", ",", "[", "]", ":", "@");
            RegisterBracePair("(", ")");
            RegisterBracePair("{", "}");
            RegisterBracePair("[", "]");
            RegisterBracePair("<", ">");

            //automatically add NewLine before EOF so that our BNF rules work correctly when there's no final line break in source
            this.LanguageFlags = LanguageFlags.NewLineBeforeEOF;
        }
    }
}
