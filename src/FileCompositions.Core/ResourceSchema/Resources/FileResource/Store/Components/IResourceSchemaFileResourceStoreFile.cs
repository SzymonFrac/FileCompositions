using FileCompositions.Core.File.Resource.Builder;

namespace FileCompositions.Core.Schema.Resources.FileResource.Store.Components;

public interface IResourceSchemaFileResourceStoreFile
{
    IResourceSchemaFileResourceStoreRegister File(Action<IFileResourceBuilder> config);
}
