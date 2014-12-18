using System;
using System.Collections.Generic;
using CTripOSS.Baiji.Generator.Java.Context;
using CTripOSS.Baiji.Generator.Java.Visitor;
using CTripOSS.Baiji.IDLParser.Visitor;

namespace CTripOSS.Baiji.Generator.Java
{
    public class JavaGenerator : Generator
    {
        private static readonly IDictionary<string, IList<string>> TEMPLATES = new Dictionary<string, IList<string>>
        {
            {"java-regular", new List<string> {"java_common_st", "java_regular_st"}},
            {"java-immutable", new List<string> {"java_common_st", "java_immutable_st"}},
            {"java-ctor", new List<string> {"java_common_st", "java_ctor_st"}},
        };

        public JavaGenerator(GeneratorConfig generatorConfig)
            : base(generatorConfig, TEMPLATES)
        {
        }

        protected override IVisitor CreateCodeGenerator(DocumentContext context)
        {
            return new JavaCodeGenerator(_templateLoader, context, _generatorConfig, _outputFolder);
        }

        protected override DocumentContext CreateDocumentContext(Uri uri, string idlNamespace, GeneratorConfig config,
            TypeRegistry typeRegistry)
        {
            return new JavaDocumentContext(uri, idlNamespace, config, typeRegistry);
        }
    }
}