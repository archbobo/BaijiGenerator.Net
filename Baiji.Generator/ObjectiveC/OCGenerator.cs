using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTripOSS.Baiji.IDLParser.Visitor;
using CTripOSS.Baiji.Generator.ObjectiveC.Context;
using CTripOSS.Baiji.Generator.ObjectiveC.Visitor;

namespace CTripOSS.Baiji.Generator.ObjectiveC
{
    public class OCGenerator : Generator
    {
        private static readonly IDictionary<string, IList<string>> TEMPLATES = new Dictionary<string, IList<string>>
        {
            {"oc-regular", new List<string> {"objectivec_common_st", "objectivec_regular_st"}},
        };

        private static readonly IList<string> RESERVEDPREFX = new List<string> {"NS", "AB", "IB"};

        public OCGenerator(GeneratorConfig generatorConfig)
            : base(generatorConfig, TEMPLATES)
        {
        }

        protected override IVisitor CreateCodeGenerator(DocumentContext context)
        {
            return new OCCodeGenerator(_templateLoader, context, _generatorConfig, _outputFolder);
        }

        protected override DocumentContext CreateDocumentContext(Uri uri, string idlNamespace, GeneratorConfig config,
            TypeRegistry typeRegistry)
        {
            /*var upperNamespace = idlNamespace.ToUpper();
            if (RESERVEDPREFX.Contains(upperNamespace) || upperNamespace.Contains("_") || upperNamespace.Contains("."))
            {
                throw new ArgumentException(idlNamespace + " wrong!!!!");
            }*/

            return new OCDocumentContext(uri, idlNamespace, config, typeRegistry);
        }

        public override Baiji.Generator.Visitor.TypeVisitor CreateTypeVisitor(string codeNamespace, DocumentContext documentContext)
        {
            return new OCTypeVisitor(codeNamespace, documentContext);
        }
    }
}
