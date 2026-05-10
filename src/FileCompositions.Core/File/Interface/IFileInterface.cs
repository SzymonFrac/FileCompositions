using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Location;

namespace FileCompositions.Core.File.Interface;

// IFileResourceInterface : IFileInterface<Required>, and for Specialised...
public interface IFileInterface<TPlacement>
    where TPlacement : DefinitionPlacement
{
    internal IStorageBackend StorageBackend { get; }

    internal StorageLocation Location { get; }
}
