using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Init;

public interface IDirectoryInit<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    internal IFileSystem StorageBackend { get; }

    internal FileSystemAddress GetAddress();
    internal DirectoryDefinitionKey GetKey();
    internal ValueTask InitializeAsync(CancellationToken cancellationToken = default);
}
