using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.FileSystem.Location.Implementations;
using FileCompositions.Core.FileSystem.Resource.Name;
using static System.Environment;

namespace FileCompositions.Core.FileSystem.Address.Implementations;

public sealed record LocalFileSystemAddress : FileSystemAddress
{
    private LocalFileSystemAddress(string value) => Value = value;

    public static LocalFileSystemAddress Create(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException(nameof(path));

        return new LocalFileSystemAddress(Path.TrimEndingDirectorySeparator(path));
    }
    public static LocalFileSystemAddress Create(params ReadOnlySpan<string> path) =>
        new(Path.Combine(path));
    public static LocalFileSystemAddress Create(SpecialFolder logical) =>
        new(GetFolderPath(logical));
    public static LocalFileSystemAddress Create(SpecialFolder logical, params ReadOnlySpan<string> path) =>
        new(Path.Combine([GetFolderPath(logical), .. path]));

    public LocalFileSystemAddress Extend(params ReadOnlySpan<string> path) =>
        this with { Value = Path.Combine([Value, .. path]) };

    public override FileSystemLocation With(FileSystemResourceName name) => new LocalFileSystemLocation(this, name);
    public override string ToString() => Value;
}
