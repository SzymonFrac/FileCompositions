using FileCompositions.Core.File.Name;
using FileCompositions.Core.FileSystem.Location;

namespace FileCompositions.Core.FileSystem.Address;

public abstract record FileSystemAddress
{
    protected string Value { get; }

    public ReadOnlySpan<char> FullPath => Value;

    protected FileSystemAddress(ReadOnlySpan<char> value) => Value = value.ToString();

    public abstract FileSystemLocation With(FileName name);
    public override string ToString() => Value;
}
