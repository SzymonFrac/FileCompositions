using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;

namespace FileCompositions.Core.File.Definition;

public interface IFileDefinition<TOwnership, TNecessity> : IFileDefinition, IFileResource
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    FileDefinitionKey Key { get; }
}

public interface IFileDefinition
{
    abstract static StorageResourceExtension Extension { get; }
    internal abstract static IFileResource Convert(IDirectoryLocation directory, StorageResourceName name);
}
