namespace FileCompositions.Core.Storage.ResourceName.Extension;

public readonly record struct StorageResourceExtension
{
    public string Value { get; }
    internal StorageResourceExtension(string value) => Value = value;
    internal static StorageResourceExtension Create(string value)
    {
        Validate(value);
        return new(value);
    }

    public override string ToString() => Value;
    
    private static void Validate(string value)
    {
        if (!value.StartsWith('.'))
            throw new ArgumentException($"{nameof(StorageResourceExtension)} must start with a '.'", nameof(value));
        
        if (string.IsNullOrWhiteSpace(value[1..]))
            throw new ArgumentException($"{nameof(StorageResourceExtension)} cannot be empty", nameof(value));
    }
}