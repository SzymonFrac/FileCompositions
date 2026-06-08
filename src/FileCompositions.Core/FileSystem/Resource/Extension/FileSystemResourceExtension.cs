namespace FileCompositions.Core.FileSystem.Resource.Extension;

public readonly record struct FileSystemResourceExtension
{
    public string Value { get; }
    internal FileSystemResourceExtension(string value) => Value = value;
    internal static FileSystemResourceExtension Create(string value)
    {
        if (!value.StartsWith('.'))
            throw new ArgumentException($"{nameof(FileSystemResourceExtension)} must start with a '.'", nameof(value));

        if (string.IsNullOrWhiteSpace(value[1..]))
            throw new ArgumentException($"{nameof(FileSystemResourceExtension)} cannot be empty", nameof(value));

        return new(value);
    }

    public override string ToString() => Value;
}