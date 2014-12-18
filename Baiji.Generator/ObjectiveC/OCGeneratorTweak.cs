using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTripOSS.Baiji.Generator.ObjectiveC
{
    public static class OCGeneratorTweak
    {
        public static readonly string NONE = "NONE";

        /// <summary>
        /// Use the java namespace, not the Baiji IDL namespace
        /// </summary>
        public static readonly string USE_PLAIN_JAVA_NAMESPACE = "USE_IDL_OC_NAMESPACE";

        public static readonly string GEN_COMMENTS = "GEN_COMMENTS";

        /// <summary>
        /// Auto Release
        /// </summary>
        public static readonly string AUTO_RELEASE = "AUTO_RELEASE";
    }
}
