using System;
using System.IO;
using System.Net;
using System.Text;
using CTripOSS.Baiji.IDLParser.Model;
using Irony.Parsing;

namespace CTripOSS.Baiji.IDLParser
{
    public static class IdlParser
    {
        /// <summary>
        /// Build a Baiji idl document model
        /// </summary>
        /// <param name="idlUri">uri to idl</param>
        /// <returns>an idl document model</returns>
        public static Document BuildDocument(Uri idlUri)
        {
            var idlText = ReadTextFromUri(idlUri);
            return BuildDocument(idlText);
        }

        /// <summary>
        /// Build a Baiji idl document model
        /// </summary>
        /// <param name="idlText">idl text</param>
        /// <returns>an idl document model</returns>
        public static Document BuildDocument(string idlText)
        {
            var parseTree = ParseBaijiIdl(idlText);
            if (parseTree.HasErrors())
            {
                throw new Exception("Unexpected parse error(s): " + string.Join("\n", parseTree.ParserMessages));
            }
            Document doc = DocumentBuilder.BuildDocument(parseTree.Root);
            return doc;
        }

        /// <summary>
        /// Build a parse tree from Baiji idl
        /// </summary>
        /// <param name="idl">idl text</param>
        /// <returns>a parse tree</returns>
        public static ParseTree ParseBaijiIdl(string idl)
        {
            Grammar g = new IdlGrammar();
            var parser = new Parser(g);
            var parseTree = parser.Parse(idl);
            return parseTree;
        }

        private static string ReadTextFromUri(Uri uri)
        {
            if (uri.Scheme == "file")
            {
                return File.ReadAllText(uri.LocalPath, Encoding.UTF8);
            }
            var client = new WebClient();
            return client.DownloadString(uri);
        }
    }
}