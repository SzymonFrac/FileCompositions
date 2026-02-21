using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.Schema.Resources.DirectoryLocation.Registrar;
using FileCompositions.Core.Schema.Resources.Registrar;
using FileCompositions.Extensions.Host.Schema.Resources.DirectoryLocation.Registrar.Implementations;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Registrar;

namespace FileCompositions.Extensions.Host.Schema.Resources.Registrar.Implementations;

internal class HostResourceSchemaResourcesRegistrar(IHostResourceSchemaFileResourceRegistrar fileRegistrar,
    HostResourceSchemaDirectoryLocationRegistrar directoryRegistrar) : IHostResourceSchemaResourcesRegistrar
{
    private readonly HostResourceSchemaDirectoryLocationRegistrar _directoryRegistrar = directoryRegistrar;
    private readonly IHostResourceSchemaFileResourceRegistrar _fileRegistrar = fileRegistrar;

    public IResourceSchemaResourcesRegistrar Directories(Action<IResourceSchemaDirectoryLocationRegistrar> config)
    {
        config(_directoryRegistrar);
        return this;
    }

    public IHostResourceSchemaResourcesRegistrar Files(Action<IHostResourceSchemaFileResourceRegistrar> config)
    {
        config(_fileRegistrar);
        return this;
    }

    public IEnumerable<IDirectoryLocationDescriptor>? GetDirectoryDescriptors() => _directoryRegistrar?.GetDescriptors();
}
