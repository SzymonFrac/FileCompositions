using FileCompositions.Core.Directory.Definition.Key;

namespace FileCompositions.Core.Schema.Resources.FileResource.Store.Components;

public interface IResourceSchemaFileResourceStoreTo
{
    IResourceSchemaFileResourceStoreUseKey To(DirectoryDefinitionKey key);
}
