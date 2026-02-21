using FileCompositions.Core.Schema.Resources.DirectoryLocation.Registrar;

namespace FileCompositions.Core.Schema.Resources.Registrar;

public interface IResourceSchemaResourcesRegistrar
{
    IResourceSchemaResourcesRegistrar Directories(Action<IResourceSchemaDirectoryLocationRegistrar> config);
}
