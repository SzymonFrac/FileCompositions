using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.Storage.Location.Implementations;

public sealed record LocalStorageLocation(StorageAddress Address, StorageResourceName Name) : StorageLocation(Address, Name)
{
    public override string ToString() => Path.Combine(Address.ToString(), Name.ToString());
}
