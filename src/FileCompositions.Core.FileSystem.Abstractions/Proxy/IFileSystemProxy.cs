using FileCompositions.Core.FileSystem.Abstractions.Session;

namespace FileCompositions.Core.FileSystem.Abstractions.Proxy;

public interface IFileSystemProxy<TEntry>
    where TEntry : Entry
{
    internal IFileSystemSession Session { get; }
    internal TEntry Entry { get; }
}
