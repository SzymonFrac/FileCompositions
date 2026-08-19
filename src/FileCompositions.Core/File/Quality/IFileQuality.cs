using FileCompositions.Core.File.Addressing;
using FileCompositions.Core.FileSystem.Source;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Quality;

public interface IFileQuality<TOwnership, TPlacement> : IFileAddressing, FileSystemSource.IFromLocation
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement;
