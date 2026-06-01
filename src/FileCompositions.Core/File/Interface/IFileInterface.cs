using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Location;

namespace FileCompositions.Core.File.Interface;

public interface IFileInterface<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    internal IStorageBackend StorageBackend { get; }

    StorageLocation GetLocation();
}
