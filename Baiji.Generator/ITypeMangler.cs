namespace CTripOSS.Baiji.Generator
{
    public interface ITypeMangler
    {
        string MangleConstantName(string src);

        string MangleArgumentName(string src);

        string MangleMethodName(string src);

        string MangleFieldName(string src);

        string MangleTypeName(string src);

        string MangleClientName(string src);
    }
}