using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTripOSS.Baiji.Generator.Visitor;
using CTripOSS.Baiji.IDLParser.Model;

namespace CTripOSS.Baiji.Generator.ObjectiveC.Visitor
{
    internal class OCTypeVisitor : TypeVisitor
    {
        public OCTypeVisitor(string codeNamespace, DocumentContext documentContext)
            : base(codeNamespace, documentContext)
        {
        }

        public override CodeType CreateCodeType(string idlNamespace, string idlName, string name, string codeNamespace, Definition definition)
        {
            return new CodeType(idlNamespace, idlName, _documentContext.TypeMangler.MangleTypeName(codeNamespace + name), codeNamespace, definition);
        }
    }
}
