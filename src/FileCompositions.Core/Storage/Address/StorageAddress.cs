using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.Storage.Address;

public abstract record StorageAddress
{
    public string Value { get; protected set; } = string.Empty;
    public abstract StorageLocation With(StorageResourceName name);
    public override string ToString() => Value;
}
