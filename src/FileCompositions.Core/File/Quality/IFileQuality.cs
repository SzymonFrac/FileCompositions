using FileCompositions.Core.File.Context;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Quality;

public interface IFileQuality<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    internal IFileContext Context { get; }

    FileSystemResourceName Name { get; }
}
