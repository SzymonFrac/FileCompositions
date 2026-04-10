using FileCompositions.Core.Storage.ResourceName.Extension;

namespace FileCompositions.Core.Storage.ResourceName;

public readonly record struct StorageResourceName
{
    public string Value { get; }
    public StorageResourceExtension Extension { get; }
    private StorageResourceName(string value, StorageResourceExtension extension) =>
        (Value, Extension) = (value, extension);

    internal static StorageResourceName Create(string value, StorageResourceExtension extension)
    {
        Validate(value);
        return new StorageResourceName(value, extension);
    }
    internal static StorageResourceName GetFromPath(string fullPath)
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
