using FileCompositions.Core.FileSystem.Addressing.Directory;
using FileCompositions.Core.FileSystem.Proxy.Directory.Source;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Quality;

public interface IDirectoryQuality<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    FileSystemDirectoryAddressing Addressing { get; }
    internal IFileSystemDirectoryProxySource ProxySource { get; }
}
