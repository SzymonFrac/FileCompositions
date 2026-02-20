using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Store.Components;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Store;

public interface IHostResourceSchemaFileResourceStore :
    IHostResourceSchemaFileResourceStoreTo,
    IHostResourceSchemaFileResourceStoreUseKey,
    IHostResourceSchemaFileResourceStoreFile,
    IHostResourceSchemaFileResourceStoreRegister;
