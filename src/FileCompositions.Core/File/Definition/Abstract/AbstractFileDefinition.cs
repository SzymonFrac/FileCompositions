using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Init;
using FileCompositions.Core.File.Interface;
using FileCompositions.Core.File.Operator;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Abstract;

internal abstract class AbstractFileDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, FileSystemResourceName name)
    : IFileDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public IFileContext Context { get; } = context;
    public FileDefinitionKey Key { get; } = key;
    public FileSystemResourceName Name { get; } = name;

    public FileSystemLocation GetLocation() => Context.Address.With(Name);
    public FileDefinitionKey? GetKey() => Key;
    public abstract ValueTask InitializeAsync(CancellationToken cancellationToken = default);

    IFileSystem IFileInterface<TOwnership, TPlacement>.StorageBackend => Context.StorageBackend;
    IFileSystem IFileInit<TOwnership, TPlacement>.StorageBackend => Context.StorageBackend;
    IFileSystem IFileOperator<TOwnership, TPlacement>.StorageBackend => Context.StorageBackend;
}