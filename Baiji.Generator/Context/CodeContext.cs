namespace CTripOSS.Baiji.Generator.Context
{
    public interface CodeContext
    {
        string[] DocStringLines
        {
            get;
        }

        string Namespace
        {
            get;
        }

        string TypeName
        {
            get;
        }
    }
}