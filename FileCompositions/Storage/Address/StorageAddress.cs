namespace FileCompositions.Core.Storage.Address;

public readonly record struct StorageAddress
{
    public string Value { get; }
    private StorageAddress(string value) => Value = value;

    public static StorageAddress Create(string value) =>
        string.IsNullOrWhiteSpace(value) ?
            throw new ArgumentException("Address cannot be empty", nameof(value)) :
            new StorageAddress(Normalize(value));

    private static string Normalize(string value) =>
        Path.TrimEndingDirectorySeparator(value);

    public override string ToString() => Value;
}

//public readonly record struct StoragePath
//{
//    public string Value { get; }
//    private StoragePath(string value) => Value = value;
//    public static StoragePath Create(string value) =>
//        string.IsNullOrWhiteSpace(value) ?
//            throw new ArgumentException("Path cannot be empty", nameof(value)) :
//            new StoragePath(Normalize(value));

//    private static string Normalize(string value) =>
//        Path.TrimEndingDirectorySeparator(value);
//}

//class A
//{
//    void a()
//    {
//        var a = new StorageAddress(StoragePath.Create("path"));
//        var b = a with { Path = StoragePath.Create("new") };

//    }
//}