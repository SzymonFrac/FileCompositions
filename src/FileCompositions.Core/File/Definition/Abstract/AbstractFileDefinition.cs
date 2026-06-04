using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Definition.Abstract;

internal abstract class AbstractFileDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, StorageResourceName name)
    : IFileDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public IFileContext Context { get; } = context;
    public FileDefinitionKey Key { get; } = key;
    public StorageResourceName Name { get; } = name;

    public StorageLocation GetLocation() => Context.Address.With(Name);
    public abstract ValueTask InitializeAsync(CancellationToken cancellationToken = default);
}