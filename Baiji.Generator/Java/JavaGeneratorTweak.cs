namespace CTripOSS.Baiji.Generator.Java
{
    public static class JavaGeneratorTweak
    {
        public static readonly string NONE = "NONE";

        /// <summary>
        /// Use the java namespace, not the Baiji IDL namespace
        /// </summary>
        public static readonly string USE_PLAIN_JAVA_NAMESPACE = "USE_PLAIN_JAVA_NAMESPACE";

        public static readonly string GEN_COMMENTS = "GEN_COMMENTS";

        /// <summary>
        /// Generate public fields. If not specified, private fields will be generated.
        /// </summary>
        public static readonly string GEN_PUBLIC_FIELDS = "GEN_PUBLIC_FIELDS";

        /// <summary>
        /// Generate service stub
        /// </summary>
        public static readonly string GEN_SERVICE_STUB = "GEN_SERVICE_STUB";

        /// <summary>
        /// Generate client proxy
        /// </summary>
        public static readonly string GEN_CLIENT_PROXY = "GEN_CLIENT_PROXY";
    }
}