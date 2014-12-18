using System;
using System.Text;

namespace CTripOSS.Baiji.Generator.CSharp
{
    internal class CSharpTypeMangler : ITypeMangler
    {
        #region Implementation of ITypeMangler
        public string MangleConstantName(string src)
        {
            if (string.IsNullOrWhiteSpace(src))
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            bool lowerCase = false;
            for (int i = 0; i < src.Length; i++)
            {
                if (char.IsUpper(src[i]))
                {
                    if (lowerCase)
                    {
                        sb.Append('_');
                    }
                    sb.Append(Char.ToUpper(src[i]));
                    lowerCase = false;
                }
                else
                {
                    sb.Append(char.ToUpper(src[i]));
                    if (char.IsLetter(src[i]))
                    {
                        lowerCase = true;
                    }
                }
            }
            return sb.ToString();
        }

        public string MangleArgumentName(string src)
        {
            return MangleCSharpName(src, false);
        }

        public string MangleMethodName(string src)
        {
            return MangleCSharpName(src, true);
        }

        public string MangleFieldName(string src)
        {
            return MangleCSharpName(src, false);
        }

        public string MangleTypeName(string src)
        {
            return MangleCSharpName(src, true);
        }

        public string MangleClientName(string src)
        {
            return MangleCSharpName(src, true) + "Client";
        }

        public string MangleServiceName(string src)
        {
            return "I" + MangleCSharpName(src, true);
        }
        #endregion

        #region [Private Methods]
        private static string MangleCSharpName(string src, bool capitalize)
        {
            if (string.IsNullOrWhiteSpace(src))
            {
                throw new ArgumentException("Input name must not be blank!", "src");
            }

            var sb = new StringBuilder();
            sb.Append(capitalize ? Char.ToUpper(src[0]) : Char.ToLower(src[0]));
            var forceUpCase = false;
            for (int i = 1; i < src.Length; i++)
            {
                if (src[i] == '_')
                {
                    forceUpCase = true;
                    continue;
                }
                sb.Append(forceUpCase ? char.ToUpper(src[i]) : src[i]);
                forceUpCase = false;
            }
            return sb.ToString();
        }
        #endregion
    }
}