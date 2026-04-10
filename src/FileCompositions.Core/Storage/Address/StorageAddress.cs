namespace FileCompositions.Core.Storage.Address;

public readonly record struct StorageAddress
{
    public string Value { get; }
    private StorageAddress(string value) => Value = value;

    public static StorageAddress Create(string value) =>
        string.IsNullOrWhiteSpace(value) ?
            throw new ArgumentException("Address cannot be empty", nameof(value)) :
            new StorageAddress(Normalize(value));
    public static StorageAddress Create(params string[] value) =>
        value.Any(string.IsNullOrEmpty) ?
            throw new ArgumentException("Address cannot be empty", nameof(value)) :
            new StorageAddress(Normalize(Path.Combine(value)));

    private static string Normalize(string value) =>
        Path.TrimEndingDirectorySeparator(value);

    public override string ToString() => Value;
}