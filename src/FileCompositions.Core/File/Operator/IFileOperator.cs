using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Location;

namespace FileCompositions.Core.File.Operator;

public interface IFileOperator<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    internal IStorageBackend StorageBackend { get; }

    internal StorageLocation GetLocation();
}
