using FileCompositions.Core.FileResource.Key;

namespace FileCompositions.Core.Schema.Resources.FileResource.Store.Components;

public interface IResourceSchemaFileResourceStoreUseKey
{
    IResourceSchemaFileResourceStoreFile UseKey(FileResourceKey key);
}
