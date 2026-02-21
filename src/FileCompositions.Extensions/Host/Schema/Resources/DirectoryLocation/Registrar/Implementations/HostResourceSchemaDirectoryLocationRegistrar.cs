using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.Schema.Resources.DirectoryLocation.Registrar;
using FileCompositions.Core.Schema.Resources.DirectoryLocation.Store.Components;
using FileCompositions.Extensions.Host.Schema.Resources.DirectoryLocation.Store.Implementations;
using FileCompositions.Extensions.Host.StorageBackend.ActivationContext.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Resources.DirectoryLocation.Registrar.Implementations;

internal class HostResourceSchemaDirectoryLocationRegistrar(in IServiceCollection settingServices) : IResourceSchemaDirectoryLocationRegistrar
{
    private readonly IServiceCollection _settingServices = settingServices;
    private readonly List<IDirectoryLocationDescriptor> _descriptors = [];

    public IResourceSchemaDirectoryLocationRegistrar Store(Action<IResourceSchemaDirectoryLocationStoreUseKey> config)
    {
        var store = new HostResourceSchemaDirectoryLocationStore();
        config(store);

        var descriptor = store.BuildDescriptor();
        _descriptors.Add(descriptor);

        _settingServices.AddKeyedSingleton<IDirectoryLocation>(descriptor.Key.Value, (sp, key) =>
        {
            var activationContext = sp.GetRequiredService<HostStorageBackendActivationContext>();
            return descriptor.Activate(activationContext);
        });

        return this;
    }

    public IReadOnlyList<IDirectoryLocationDescriptor> GetDescriptors() => _descriptors;
}
