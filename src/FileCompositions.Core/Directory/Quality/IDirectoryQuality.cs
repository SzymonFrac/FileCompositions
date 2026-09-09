using FileCompositions.Core.FileSystem.Addressing;
using FileCompositions.Core.FileSystem.Proxy.Directory.Source;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Quality;

public interface IDirectoryQuality<TOwnership, TNecessity>
    where TOwnership : Ownership
    where TNecessity : Necessity
{
    DirectoryAddressing Addressing { get; }
    internal IDirectoryProxySource ProxySource { get; }
}
