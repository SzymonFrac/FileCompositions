using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.FileSystem.Abstractions;

public abstract record Entry
{
    public sealed record Directory(Address Address) : Entry;
    public sealed record File(Location Location) : Entry;
}