using FileCompositions.Core.ResourceSchema.StorageBackend.Registrar;
using FileCompositions.Extensions.Host.Schema.Register;

namespace FileCompositions.Extensions.Host.StorageBackend.Registrar;

internal interface IHostResourceSchemaStorageBackendRegistrar : IResourceSchemaStorageBackendRegistrar
{
    HostResourceSchemaRegister? Build();
}
