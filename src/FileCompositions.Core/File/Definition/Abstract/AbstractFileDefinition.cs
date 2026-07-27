using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
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

    public abstract ValueTask InitializeAsync(CancellationToken cancellationToken = default);
}