using FileCompositions.Core.FileSystem.Addressing;
using FileCompositions.Core.FileSystem.Proxy.File.Source;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Quality;

public interface IFileQuality<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    FileAddressing Addressing { get; }
    internal IFileProxySource ProxySource { get; }
}
