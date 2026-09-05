using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.FileSystem.Name;

namespace FileCompositions.Core.FileSystem.Address;

public abstract record FileSystemAddress
{
    protected string Value { get; }

    public ReadOnlySpan<char> FullPath => Value;

    protected FileSystemAddress(ReadOnlySpan<char> value) => Value = value.ToString();

    public abstract FileSystemLocation With(FileSystemFilename name);
    public override string ToString() => Value;
}
