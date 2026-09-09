namespace FileCompositions.Core.FileSystem.Addressing;

public readonly record struct Filename
{
    private readonly string _fullName;

    public ReadOnlySpan<char> Name => _fullName.LastIndexOf('.') is var dotIntext and not -1
        ? _fullName.AsSpan(0, dotIntext)
        : _fullName.AsSpan();
    public ReadOnlySpan<char> Extension => _fullName.LastIndexOf('.') is var dotIntext and not -1
        ? _fullName.AsSpan(dotIntext + 1)
        : [];
    public ReadOnlySpan<char> FullName => _fullName;


    private Filename(string fullName) => _fullName = fullName;

    internal static Filename Create(ReadOnlySpan<char> name, FileExtension extension) => new(extension.Affix(name));
    internal static Filename Create(string name, FileExtension extension) => new(extension.Affix(name));


    public override string ToString() => _fullName;
}
