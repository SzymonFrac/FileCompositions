using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Resource.Extension;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Definition;

public interface IFileDefinition<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    internal IFileContext Context { get; }

    FileDefinitionKey Key { get; }
    StorageResourceName Name { get; }

    ValueTask InitializeAsync(CancellationToken cancellationToken = default);
}

public interface IFileDefinition
{
    abstract static StorageResourceExtension Extension { get; }
}
