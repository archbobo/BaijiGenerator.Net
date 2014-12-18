using System.Collections.Generic;
using System.Linq;
using CTripOSS.Baiji.IDLParser.Model;

namespace CTripOSS.Baiji.Generator.Util
{
    public class ContextUtils
    {
        private static readonly ISet<string> COMMON_CODE_NAMESPACES = new HashSet<string>
                                                {
                                                    "com.ctriposs.baiji.rpc.common.types",
                                                    "com.ctriposs.baiji.rpc.mobile.common.types",
                                                    "CTripOSS.Baiji.Rpc.Common.Types",
                                                    "CTripOSS.Baiji.Rpc.Mobile.Common.Types",
                                                    "BJ"
                                                };

        public static Service ExtractService(DocumentContext context)
        {
            return (Service)context.Document.Definitions.FirstOrDefault(d => d is Service);
        }

        public static bool IsCommon(string codeNamespace)
        {
            return COMMON_CODE_NAMESPACES.Contains(codeNamespace);
        }
    }
}
