using FileCompositions.Core.ResourceSchema.FileSystem.Registrar;

namespace FileCompositions.Core.ResourceSchema.Builder;

public interface IResourceSchemaBuilder
{
    IResourceSchemaBuilder ConfigureStorageBackends(Action<IResourceSchemaFileSystemRegistrar> config);
}
