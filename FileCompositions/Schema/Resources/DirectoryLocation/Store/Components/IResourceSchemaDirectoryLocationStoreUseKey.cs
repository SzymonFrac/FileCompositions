using FileCompositions.Core.DirectoryLocation.Key;

namespace FileCompositions.Core.Schema.Resources.DirectoryLocation.Store.Components;

public interface IResourceSchemaDirectoryLocationStoreUseKey
{
    IResourceSchemaDirectoryLocationStoreRegister UseKey(DirectoryLocationKey key);
}
