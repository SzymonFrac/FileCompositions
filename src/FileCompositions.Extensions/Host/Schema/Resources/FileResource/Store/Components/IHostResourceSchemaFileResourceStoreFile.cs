using FileCompositions.Core.FileResource.Builder;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Store.Components;

public interface IHostResourceSchemaFileResourceStoreFile
{
    IHostResourceSchemaFileResourceStoreRegister File(Action<IFileResourceBuilder> config);
}
