using FileCompositions.Core.FileSystem.Addressing.Directory;
using FileCompositions.Core.FileSystem.Proxy.Directory.Source;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Quality;

public interface IDirectoryQuality<TOwnership, TNecessity>
    where TOwnership : Ownership
    where TNecessity : Necessity
{
    FileSystemDirectoryAddressing Addressing { get; }
    internal IFileSystemDirectoryProxySource ProxySource { get; }
}
