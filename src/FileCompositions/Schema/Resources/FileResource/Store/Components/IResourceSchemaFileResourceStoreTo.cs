using FileCompositions.Core.DirectoryLocation.Key;

namespace FileCompositions.Core.Schema.Resources.FileResource.Store.Components;

public interface IResourceSchemaFileResourceStoreTo
{
    IResourceSchemaFileResourceStoreUseKey To(DirectoryLocationKey key);
}
