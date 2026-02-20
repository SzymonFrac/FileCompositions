namespace FileCompositions.Core.Storage.ResourceName;

public readonly record struct StorageResourceName
{
    public string Value { get; }
    public string Extension { get; }
    private StorageResourceName(string value, string extension) =>
        (Value, Extension) = (value, extension);

    public static StorageResourceName Create(string value, string extension)
    {
        Validate(value, extension);
        return new StorageResourceName(value, extension);
    }
    public static StorageResourceName Create(string fullName) =>
        Create(Path.GetFileNameWithoutExtension(fullName), Path.GetExtension(fullName));

    private static void Validate(string value, string extension)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException(nameof(value), "Name cannot be null");

        if (!Path.HasExtension(extension))
            throw new ArgumentException("Extension was not valid format");
    }

    public override string ToString() =>
        Value + Extension;
}

