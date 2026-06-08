using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Definition.Init;

public interface IDirectoryDefinitionInit<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    DirectoryDefinitionKey Key { get; }
    
    internal IFileSystem StorageBackend { get; }
    internal FileSystemAddress Address { get; }
}
