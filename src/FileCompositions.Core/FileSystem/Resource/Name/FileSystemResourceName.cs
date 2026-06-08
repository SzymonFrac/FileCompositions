using FileCompositions.Core.FileSystem.Resource.Extension;

namespace FileCompositions.Core.FileSystem.Resource.Name;

public readonly record struct FileSystemResourceName
{
    public string Value { get; }
    public FileSystemResourceExtension Extension { get; }
    private FileSystemResourceName(string value, FileSystemResourceExtension extension) =>
        (Value, Extension) = (value, extension);

    internal static FileSystemResourceName Create(string value, FileSystemResourceExtension extension)
    {
        Validate(value);
        return new FileSystemResourceName(value, extension);
    }
    internal static FileSystemResourceName GetFromPath(string fullPath)
    {
        var name = Path.GetFileName(fullPath);
        var extension = Path.GetExtension(fullPath);

        Validate(name);
        return new(name, new(extension));
    }

    private static void Validate(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException(nameof(value), "Name cannot be null");
    }

    public override string ToString() =>
        Value + Extension;
}
