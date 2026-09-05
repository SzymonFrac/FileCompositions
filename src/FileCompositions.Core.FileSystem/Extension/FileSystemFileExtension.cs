namespace FileCompositions.Core.FileSystem.Extension;

public abstract record FileSystemFileExtension
{
    public abstract string Affix(ReadOnlySpan<char> name);
    public abstract string Affix(string name);
}
