using FileCompositions.Core.ResourceSchema.FileSystem.Registrar;
using FileCompositions.Hosting.ResourceSchema.Register;

namespace FileCompositions.Hosting.ResourceSchema.FileSystem.Registrar;

internal interface IHostResourceSchemaFileSystemRegistrar : IResourceSchemaFileSystemRegistrar
{
    HostResourceSchemaRegister? Build();
}
