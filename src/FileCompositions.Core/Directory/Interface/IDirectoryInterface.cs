using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Interface;

public interface IDirectoryInterface<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    internal IFileSystem StorageBackend { get; }

    FileSystemAddress Address { get; }
}
