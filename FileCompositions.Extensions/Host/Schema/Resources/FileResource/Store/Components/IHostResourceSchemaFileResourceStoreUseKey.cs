using FileCompositions.Core.FileResource.Key;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Store.Components;

public interface IHostResourceSchemaFileResourceStoreUseKey
{
    IHostResourceSchemaFileResourceStoreFile UseKey(FileResourceKey key);
}
