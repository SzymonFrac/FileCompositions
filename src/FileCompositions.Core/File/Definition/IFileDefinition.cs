using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Interface;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;

namespace FileCompositions.Core.File.Definition;

public interface IFileDefinition<TOwnership, TPlacement> : IFileInterface<TPlacement>
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
    internal abstract static IFileResource Convert(IDirectoryLocation directory, StorageResourceName name);
}
