using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Location;

namespace FileCompositions.Core.File.Definition.Init;

public interface IFileDefinitionInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    FileDefinitionKey Key { get; }

    internal IStorageBackend StorageBackend { get; }
    internal StorageLocation GetLocation();

    internal ValueTask InitializeAsync(CancellationToken cancellationToken = default);
}
