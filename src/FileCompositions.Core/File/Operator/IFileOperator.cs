using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Operator;

public interface IFileOperator<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    internal IFileSystem StorageBackend { get; }

    internal FileSystemLocation GetLocation();
}
