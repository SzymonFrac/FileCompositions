using FileCompositions.Core.File.Name;
using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.FileSystem.Location.Implementations;
using static System.Environment;

namespace FileCompositions.Core.FileSystem.Address.Implementations;

public sealed record LocalFileSystemAddress : FileSystemAddress
{
    private LocalFileSystemAddress(ReadOnlySpan<char> value) : base(value) { }

    public static LocalFileSystemAddress Create(ReadOnlySpan<char> path) =>
        path.IsWhiteSpace()
            ? throw new ArgumentException("Address cannot be empty.", nameof(path))
            : new LocalFileSystemAddress(Path.TrimEndingDirectorySeparator(path));
    public static LocalFileSystemAddress Create(params ReadOnlySpan<string> path) =>
        new(Path.Combine(path));
    public static LocalFileSystemAddress Create(SpecialFolder logical) =>
        new(GetFolderPath(logical));
    public static LocalFileSystemAddress Create(SpecialFolder logical, params ReadOnlySpan<string> path) =>
        new(Path.Combine([GetFolderPath(logical), .. path]));

    public LocalFileSystemAddress Extend(params ReadOnlySpan<string> path) =>
        new(Path.Combine([Value, .. path]));

    public override FileSystemLocation With(FileName name) => new LocalFileSystemLocation(this, name);
    public override string ToString() => Value;
}
