using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Init;

public interface IFileInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    internal IFileSystem StorageBackend { get; }

    internal FileSystemLocation GetLocation();
    internal FileDefinitionKey? GetKey();
    internal ValueTask InitializeAsync(CancellationToken cancellationToken = default);
}
