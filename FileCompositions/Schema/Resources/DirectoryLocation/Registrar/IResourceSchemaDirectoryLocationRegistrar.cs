using FileCompositions.Core.Schema.Resources.DirectoryLocation.Store.Components;

namespace FileCompositions.Core.Schema.Resources.DirectoryLocation.Registrar;

public interface IResourceSchemaDirectoryLocationRegistrar
{
    IResourceSchemaDirectoryLocationRegistrar Store(Action<IResourceSchemaDirectoryLocationStoreUseKey> config);
}