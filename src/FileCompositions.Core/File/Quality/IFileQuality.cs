using FileCompositions.Core.FileSystem.Abstractions;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;
using FileCompositions.Core.FileSystem.Abstractions.Proxy.Source;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Quality;

public interface IFileQuality<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    FileAddressing Addressing { get; }
    internal IFileSystemProxySource<Entry.File> ProxySource { get; }
}
