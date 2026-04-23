using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.ResourceSchema.StorageBackend.Registrar;

public interface IResourceSchemaStorageBackendRegistrar
{
    IResourceSchemaStorageBackendRegistrar Register<TBackend>()
        where TBackend : class, IStorageBackend;
}
