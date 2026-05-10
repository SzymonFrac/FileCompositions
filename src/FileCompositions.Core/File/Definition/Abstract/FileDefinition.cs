using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Interface;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Location.Extensions;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Abstract;

internal abstract class FileDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, StorageResourceName name)
    : IFileDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public IFileContext Context { get; } = context;

    public FileDefinitionKey Key { get; } = key;
    public StorageResourceName Name { get; } = name;

    IStorageBackend IFileInterface<TPlacement>.StorageBackend => Context.StorageBackend;
    StorageLocation IFileInterface<TPlacement>.Location => Context.Address.With(Name);
}