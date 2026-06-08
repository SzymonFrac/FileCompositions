using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.FileSystem.Address;

public abstract record FileSystemAddress
{
    public string Value { get; protected set; } = string.Empty;
    public abstract FileSystemLocation With(FileSystemResourceName name);
    public override string ToString() => Value;
}
