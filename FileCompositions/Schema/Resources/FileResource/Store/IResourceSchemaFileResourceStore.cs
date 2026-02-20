using FileCompositions.Core.Schema.Resources.FileResource.Store.Components;

namespace FileCompositions.Core.Schema.Resources.FileResource.Store;

public interface IResourceSchemaFileResourceStore :
    IResourceSchemaFileResourceStoreTo,
    IResourceSchemaFileResourceStoreUseKey,
    IResourceSchemaFileResourceStoreFile;
