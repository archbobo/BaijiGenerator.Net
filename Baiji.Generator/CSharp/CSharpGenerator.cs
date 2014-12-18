using System;
using System.Collections.Generic;
using CTripOSS.Baiji.Generator.CSharp.Context;
using CTripOSS.Baiji.Generator.CSharp.Visitor;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.Generator.CSharp
{
    public class CSharpGenerator : Generator
    {
        private static readonly IDictionary<string, IList<string>> TEMPLATES = new Dictionary<string, IList<string>>
        {
            {"csharp-regular", new List<string> {"csharp_common_st", "csharp_regular_st"}},
            {"csharp-immutable", new List<string> {"csharp_common_st", "csharp_immutable_st"}},
            {"csharp-ctor", new List<string> {"csharp_common_st", "csharp_ctor_st"}},
        };

        public CSharpGenerator(GeneratorConfig generatorConfig)
            : base(generatorConfig, TEMPLATES)
        {
        }

        protected override IVisitor CreateCodeGenerator(DocumentContext context)
        {
            return new CSharpCodeGenerator(_templateLoader, context, _generatorConfig, _outputFolder);
        }

        protected override DocumentContext CreateDocumentContext(Uri uri, string idlNamespace, GeneratorConfig config,
            TypeRegistry typeRegistry)
        {
            return new CSharpDocumentContext(uri, idlNamespace, config, typeRegistry);
        }
    }
}