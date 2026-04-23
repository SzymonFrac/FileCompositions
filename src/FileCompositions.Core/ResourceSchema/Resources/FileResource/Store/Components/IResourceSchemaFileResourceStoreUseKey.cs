using FileCompositions.Core.File.Definition.Key;

namespace FileCompositions.Core.Schema.Resources.FileResource.Store.Components;

public interface IResourceSchemaFileResourceStoreUseKey
{
    IResourceSchemaFileResourceStoreFile UseKey(FileDefinitionKey key);
}
