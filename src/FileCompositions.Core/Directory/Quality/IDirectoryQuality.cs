using FileCompositions.Core.Directory.Addressing;
using FileCompositions.Core.FileSystem.Source;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Quality;

public interface IDirectoryQuality<TOwnership, TNecessity> : IDirectoryAddressing, FileSystemSource.IFromAddress
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;
