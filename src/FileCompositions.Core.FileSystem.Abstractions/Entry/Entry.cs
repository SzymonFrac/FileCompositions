using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.FileSystem.Abstractions;

public abstract record Entry
{
    public sealed record Directory(DirectoryAddressing Addressing) : Entry;
    public sealed record File(FileAddressing Addressing) : Entry;
}