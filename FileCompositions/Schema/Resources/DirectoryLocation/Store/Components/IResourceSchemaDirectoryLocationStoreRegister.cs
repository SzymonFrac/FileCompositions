using FileCompositions.Core.DirectoryLocation.Builder;

namespace FileCompositions.Core.Schema.Resources.DirectoryLocation.Store.Components;

public interface IResourceSchemaDirectoryLocationStoreRegister
{
    void Register(Action<IDirectoryLocationBuilder> config);
}
