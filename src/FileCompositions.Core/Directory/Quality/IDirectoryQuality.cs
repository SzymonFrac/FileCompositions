using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Quality;

public interface IDirectoryQuality<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    internal IDirectoryContext Context { get; }

    FileSystemAddress Address { get; }
}
