using FileCompositions.Core.FileSystem.Extension;

namespace FileCompositions.Core.FileSystem.Name;

public readonly record struct FileSystemFilename
{
    private readonly string _fullName;

    public ReadOnlySpan<char> Name => _fullName.LastIndexOf('.') is var dotIntext and not -1
        ? _fullName.AsSpan(0, dotIntext)
        : _fullName.AsSpan();
    public ReadOnlySpan<char> Extension => _fullName.LastIndexOf('.') is var dotIntext and not -1
        ? _fullName.AsSpan(dotIntext + 1)
        : [];
    public ReadOnlySpan<char> FullName => _fullName;


    private FileSystemFilename(string fullName) => _fullName = fullName;

    internal static FileSystemFilename Create(ReadOnlySpan<char> name, FileSystemFileExtension extension) => new(extension.Affix(name));
    internal static FileSystemFilename Create(string name, FileSystemFileExtension extension) => new(extension.Affix(name));


    public override string ToString() => _fullName;
}
