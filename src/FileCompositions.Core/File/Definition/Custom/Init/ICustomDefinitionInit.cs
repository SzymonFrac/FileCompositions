using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Location;

namespace FileCompositions.Core.File.Definition.Custom.Init;

public interface ICustomDefinitionInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    FileDefinitionKey Key { get; }

    IStorageBackend StorageBackend { get; }
    StorageLocation GetLocation();

    ValueTask InitializeAsync(CancellationToken cancellationToken = default);
}
