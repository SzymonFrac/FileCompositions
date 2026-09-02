using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Directory.Quality;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Request;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Directory.Definition;

public interface IDirectoryDefinition<TOwnership, TNecessity> : IDirectoryQuality<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    DirectoryDefinitionKey Key { get; }

    internal TDefinition RequestFileDefinition<TRequestOwnership, TRequestPlacement, TDefinition>(FileDefinitionRequest<TRequestOwnership, TRequestPlacement, TDefinition> request)
        where TRequestOwnership : DefinitionOwnership
        where TRequestPlacement : DefinitionPlacement
        where TDefinition : IFileDefinition<TRequestOwnership, TRequestPlacement>;

    internal Task InitializeAsync(CancellationToken cancellationToken = default);
}
