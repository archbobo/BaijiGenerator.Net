using System.Text;

namespace CTripOSS.Baiji.Helper
{
    public static class StringBuilderExtension
    {
        public static StringBuilder Indent(this StringBuilder sb, int level, string indentText = "    ")
        {
            for (int i = 0; i < level; i++)
            {
                sb.Append(indentText);
            }
            return sb;
        }
    }
}