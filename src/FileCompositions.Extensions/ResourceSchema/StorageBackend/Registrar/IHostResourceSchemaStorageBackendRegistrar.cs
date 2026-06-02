using FileCompositions.Core.ResourceSchema.StorageBackend.Registrar;
using FileCompositions.Hosting.ResourceSchema.Register;

namespace FileCompositions.Hosting.ResourceSchema.StorageBackend.Registrar;

internal interface IHostResourceSchemaStorageBackendRegistrar : IResourceSchemaStorageBackendRegistrar
{
    HostResourceSchemaRegister? Build();
}
