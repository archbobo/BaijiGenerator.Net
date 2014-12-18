namespace CTripOSS.Baiji.Generator.CSharp
{
    public static class CSharpGeneratorTweak
    {
        public static readonly string NONE = "NONE";

        /// <summary>
        /// Make generated Service extend IDisposable and add a Dispose() method
        /// </summary>
        public static readonly string ADD_DISPOSABLE_INTERFACE = "ADD_DISPOSABLE_INTERFACE";

        /// <summary>
        /// Use the csharp namespace, not the Baiji IDL namespace
        /// </summary>
        public static readonly string USE_PLAIN_CSHARP_NAMESPACE = "USE_PLAIN_CSHARP_NAMESPACE";

        public static readonly string GEN_PROTOBUF_ATTRIBUTE = "GEN_PROTOBUF_ATTRIBUTE";

        public static readonly string GEN_COMMENTS = "GEN_COMMENTS";

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