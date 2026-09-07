using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Directory.Quality;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Request;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Definition;

public interface IDirectoryDefinition<TOwnership, TNecessity> : IDirectoryQuality<TOwnership, TNecessity>
    where TOwnership : Ownership
    where TNecessity : Necessity
{
    DirectoryDefinitionKey Key { get; }

    internal TDefinition RequestFileDefinition<TRequestOwnership, TRequestPlacement, TDefinition>(FileDefinitionRequest<TRequestOwnership, TRequestPlacement, TDefinition> request)
        where TRequestOwnership : Ownership
        where TRequestPlacement : Placement
        where TDefinition : IFileDefinition<TRequestOwnership, TRequestPlacement>;

    internal Task InitializeAsync(CancellationToken cancellationToken = default);
}
