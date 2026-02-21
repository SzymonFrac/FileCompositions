namespace FileCompositions.Core.Storage.Address.Extensions;

public static class ExtendStorageAddress
{
    extension(StorageAddress storageAddress)
    {
        public StorageAddress Extend(string path) => StorageAddress.Create(Path.Combine(storageAddress.Value, path));
    }
}
