using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Resource.Specialized;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;

namespace FileCompositions.Core.File.Definition;

public interface IFileDefinition
{
    abstract static StorageResourceExtension Extension { get; }
    FileDefinitionKey Key { get; }

    internal abstract static ISpecializedFileResource Convert(IDirectoryLocation directory, StorageResourceName name);
}
