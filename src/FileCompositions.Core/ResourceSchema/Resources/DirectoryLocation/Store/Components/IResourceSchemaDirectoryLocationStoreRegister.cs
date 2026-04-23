using FileCompositions.Core.Directory.Location.Builder;

namespace FileCompositions.Core.Schema.Resources.DirectoryLocation.Store.Components;

public interface IResourceSchemaDirectoryLocationStoreRegister
{
    void Register(Action<IDirectoryLocationBuilder> config);
}
