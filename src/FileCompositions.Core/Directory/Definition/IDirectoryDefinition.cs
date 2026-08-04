using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Directory.Quality;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Definition;

public interface IDirectoryDefinition<TOwnership, TNecessity> : IDirectoryQuality<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    DirectoryDefinitionKey Key { get; }

    internal ValueTask InitializeAsync(CancellationToken cancellationToken = default);
}
