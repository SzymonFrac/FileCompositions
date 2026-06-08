using FileCompositions.Core.FileSystem;
using FileCompositions.Core.ResourceSchema.FileSystem.Registrar;
using FileCompositions.Hosting.ResourceSchema.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.ResourceSchema.FileSystem.Registrar.Implementations;

internal sealed class HostResourceSchemaFileSystemRegistrar : IHostResourceSchemaFileSystemRegistrar
{
    private HostResourceSchemaRegister? register;

    public IResourceSchemaFileSystemRegistrar Register<TFileSystem>()
        where TFileSystem : class, IFileSystem
    {
        register += (in services) => services.AddSingleton<TFileSystem>();

        return this;
    }
    public HostResourceSchemaRegister? Build() => register;
}

