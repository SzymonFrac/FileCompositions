using FileCompositions.Core.FileSystem.Abstractions;
using FileCompositions.Core.FileSystem.Abstractions.Proxy.Source;
using FileCompositions.Core.Quality;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.Directory.Quality;

public interface IDirectoryQuality<TOwnership, TNecessity>
    where TOwnership : Ownership
    where TNecessity : Necessity
{
    internal IFileSystemProxySource<Entry.Directory> ProxySource { get; }
    Address Address { get; }
}
