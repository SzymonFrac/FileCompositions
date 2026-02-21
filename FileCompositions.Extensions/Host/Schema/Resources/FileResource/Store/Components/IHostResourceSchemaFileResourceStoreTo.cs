using FileCompositions.Core.DirectoryLocation.Key;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Store.Components;

public interface IHostResourceSchemaFileResourceStoreTo
{
    IHostResourceSchemaFileResourceStoreUseKey To(DirectoryLocationKey key);
}
