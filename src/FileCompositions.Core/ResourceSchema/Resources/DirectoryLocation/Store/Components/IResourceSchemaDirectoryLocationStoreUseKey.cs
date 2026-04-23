using FileCompositions.Core.Directory.Definition.Key;

namespace FileCompositions.Core.Schema.Resources.DirectoryLocation.Store.Components;

public interface IResourceSchemaDirectoryLocationStoreUseKey
{
    IResourceSchemaDirectoryLocationStoreRegister UseKey(DirectoryDefinitionKey key);
}
