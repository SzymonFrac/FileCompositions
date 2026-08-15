namespace FileCompositions.Core.File.Extension.None;

internal sealed record NoFileExtension : FileExtension
{
    public sealed override string Affix(ReadOnlySpan<char> name) => name.ToString();
    public sealed override string Affix(string name) => name;

    public sealed override string ToString() => string.Empty;
}
