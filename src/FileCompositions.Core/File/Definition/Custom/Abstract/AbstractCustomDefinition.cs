using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Definition.Custom.Abstract;

public abstract class AbstractCustomDefinition<TOwnership, TPlacement, TDefinition>(IFileContext context, FileDefinitionKey key, StorageResourceName name)
    : ICustomDefinition<TOwnership, TPlacement, TDefinition>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : ICustomDefinition<TOwnership, TPlacement, TDefinition>
{
    public abstract string Extension { get; }

    public IFileContext Context { get; } = context;
    public StorageResourceName Name { get; } = name;
    public FileDefinitionKey Key { get; } = key;

    public IStorageBackend StorageBackend => Context.StorageBackend;

    public abstract TDefinition Create(in IFileContext context, FileDefinitionKey key, StorageResourceName name);
    public abstract ValueTask InitializeAsync(CancellationToken cancellationToken = default);

    public StorageLocation GetLocation() => Context.Address.With(Name);
}
