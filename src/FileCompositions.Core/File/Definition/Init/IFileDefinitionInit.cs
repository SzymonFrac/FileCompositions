using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Init;

public interface IFileDefinitionInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    FileDefinitionKey Key { get; }

    internal IFileSystem StorageBackend { get; }
    internal FileSystemLocation GetLocation();

    internal ValueTask InitializeAsync(CancellationToken cancellationToken = default);
}
