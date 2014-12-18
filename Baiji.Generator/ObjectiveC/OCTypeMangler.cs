using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTripOSS.Baiji.Generator.ObjectiveC
{
    internal class OCTypeMangler : ITypeMangler
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
                    sb.Append(char.ToUpper(src[i]));
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
            return MangleOCName(src, false);
        }

        public string MangleMethodName(string src)
        {
            return MangleOCName(src, false);
        }

        public string MangleFieldName(string src)
        {
            return MangleOCName(src, false);
        }

        public string MangleTypeName(string src)
        {
            return MangleOCName(src, true);
        }

        public string MangleClientName(string src)
        {
            return MangleTypeName(src) + "Client";
        }
        #endregion

        #region [Private Methods]
        private static string MangleOCName(string src, bool capitalize)
        {
            if (string.IsNullOrWhiteSpace(src))
            {
                throw new ArgumentException("Input name must not be blank!");
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
                sb.Append(forceUpCase ? Char.ToUpper(src[i]) : src[i]);
                forceUpCase = false;
            }
            return sb.ToString();
        }
        #endregion
    }
}
