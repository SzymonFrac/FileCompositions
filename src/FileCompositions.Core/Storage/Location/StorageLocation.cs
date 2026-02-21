using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.Storage.Location;

public readonly record struct StorageLocation(StorageAddress Address, StorageResourceName Name)
{
    public override string ToString() => Path.Combine(Address.ToString(), Name.ToString());
}
