using System.Collections.Generic;
using System.IO;
using System.Linq;
using CTripOSS.Baiji.Generator.Util;
using CTripOSS.Baiji.Generator.Visitor;

namespace CTripOSS.Baiji.Generator.CSharp.Visitor
{
    internal class CSharpCodeGenerator : CodeGenerator
    {
        public CSharpCodeGenerator(TemplateLoader templateLoader, DocumentContext context, GeneratorConfig config,
            DirectoryInfo outputFolder) : base(templateLoader, context, config, outputFolder)
        {
        }

        protected override string FileExtension
        {
            get
            {
                return ".cs";
            }
        }

        protected override string GenServiceTweak
        {
            get
            {
                return CSharpGeneratorTweak.GEN_SERVICE_STUB;
            }
        }

        protected override string GenClientTweak
        {
            get
            {
                return CSharpGeneratorTweak.GEN_CLIENT_PROXY;
            }
        }

        protected override IDictionary<string, bool> GetTweakMap()
        {
            return _config.GeneratorTweaks.ToDictionary(t => t, t => true);
        }
    }
}