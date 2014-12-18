using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTripOSS.Baiji.Generator.Util;
using CTripOSS.Baiji.Generator.Visitor;
using System.IO;
using CTripOSS.Baiji.IDLParser.Model;
using CTripOSS.Baiji.Generator.Context;

namespace CTripOSS.Baiji.Generator.ObjectiveC.Visitor
{
    internal class OCCodeGenerator : CodeGenerator
    {
        public OCCodeGenerator(TemplateLoader templateLoader, DocumentContext context, GeneratorConfig config,
            DirectoryInfo outputFolder) : base(templateLoader, context, config, outputFolder)
        {
        }

        protected override string FileExtension
        {
            get
            {
                return ".m";
            }
        }

        protected string HeaderFileExtension
        {
            get
            {
                return ".h";
            }
        }

        protected override string GenServiceTweak
        {
            get
            {
                return "";
            }
        }

        protected override string GenClientTweak
        {
            get
            {
                return "";
            }
        }

        protected override IDictionary<string, bool> GetTweakMap()
        {
            return _config.GeneratorTweaks.ToDictionary(t => t, t => true);
        }

        public override void Visit(Struct @struct)
        {
            var structContext = GetStructContext(@struct);

            Render(structContext, "structHeader", HeaderFileExtension);
            Render(structContext, "struct", null);
        }

        protected override string GetOutputFileName(CodeContext context, string fileExtension)
        {
            DirectoryInfo folder = _outputFolder;

            var fileName = Path.Combine(folder.FullName, context.TypeName + fileExtension);
            return fileName;
        }

        public override void Visit(IntegerEnum integerEnum)
        {
            var enumContext = GetEnumContext(integerEnum);

            Render(enumContext, "enumHeader", HeaderFileExtension);
            Render(enumContext, "intEnum", null);
        }
    }
}
