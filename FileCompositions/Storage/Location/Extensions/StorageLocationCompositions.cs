using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.Storage.Location.Extensions;

public static class StorageLocationCompositions
{
    extension(StorageAddress address)
    {
        public StorageLocation With(StorageResourceName name) => new(address, name);
    }

    extension(StorageResourceName name)
    {
        public StorageLocation In(StorageAddress address) => new(address, name);
    }
}

