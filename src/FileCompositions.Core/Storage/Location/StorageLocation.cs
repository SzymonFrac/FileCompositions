using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.Storage.Location;

public abstract record StorageLocation(StorageAddress Address, StorageResourceName Name);
