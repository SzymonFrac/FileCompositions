using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Location.Implementations;
using FileCompositions.Core.Storage.Resource.Name;
using static System.Environment;

namespace FileCompositions.Core.Storage.Address.Implementations;

public sealed record LocalStorageAddress : StorageAddress
{
    private LocalStorageAddress(string value) => Value = value;

    public static LocalStorageAddress Create(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException(nameof(path));

        return new LocalStorageAddress(Path.TrimEndingDirectorySeparator(path));
    }
    public static LocalStorageAddress Create(params ReadOnlySpan<string> path) =>
        new(Path.Combine(path));
    public static LocalStorageAddress Create(SpecialFolder logical) =>
        new(GetFolderPath(logical));
    public static LocalStorageAddress Create(SpecialFolder logical, params ReadOnlySpan<string> path) =>
        new(Path.Combine([GetFolderPath(logical), .. path]));

    public LocalStorageAddress Extend(params ReadOnlySpan<string> path) =>
        this with { Value = Path.Combine([Value, .. path]) };

    public override StorageLocation With(StorageResourceName name) => new LocalStorageLocation(this, name);
    public override string ToString() => Value;
}
