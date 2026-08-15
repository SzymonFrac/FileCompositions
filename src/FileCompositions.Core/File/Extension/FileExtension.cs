namespace FileCompositions.Core.File.Extension;

public abstract record FileExtension
{
    public abstract string Affix(ReadOnlySpan<char> name);
    public abstract string Affix(string name);
}
