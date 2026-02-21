using FileCompositions.Core.Schema.StorageBackend.Registrar;

namespace FileCompositions.Core.Schema.Builder;

public interface IResourceSchemaBuilder
{
    IResourceSchemaBuilder ConfigureStorageBackends(Action<IResourceSchemaStorageBackendRegistrar> config);
}
