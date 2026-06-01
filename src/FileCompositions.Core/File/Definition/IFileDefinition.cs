using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Init;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Interface;
using FileCompositions.Core.File.Operator;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Resource.Extension;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Definition;

public interface IFileDefinition<TOwnership, TPlacement> : IFileInterface<TOwnership, TPlacement>,
    IFileDefinitionInit<TOwnership, TPlacement>,
    IFileOperator<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    internal IFileContext Context { get; }

    FileDefinitionKey Key { get; }
    StorageResourceName Name { get; }
}

public interface IFileDefinition
{
    abstract static StorageResourceExtension Extension { get; }
}
