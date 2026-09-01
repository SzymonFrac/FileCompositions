using FileCompositions.Core.FileSystem.Addressing.File;
using FileCompositions.Core.FileSystem.Proxy.File.Source;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Quality;

public interface IFileQuality<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    FileSystemFileAddressing Addressing { get; }
    internal IFileSystemFileProxySource ProxySource { get; }
}
