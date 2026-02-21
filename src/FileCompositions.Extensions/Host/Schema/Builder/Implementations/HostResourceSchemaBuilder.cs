using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.DirectoryLocation.Descriptor.Implementations;
using FileCompositions.Core.Schema.Builder;
using FileCompositions.Core.Schema.StorageBackend.Registrar;
using FileCompositions.Core.Setting.Descriptor;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Extensions.Host.Schema.Implementation;
using FileCompositions.Extensions.Host.Schema.Resources.Context.Builder;
using FileCompositions.Extensions.Host.Schema.Resources.Context.Builder.Implementations;
using FileCompositions.Extensions.Host.Schema.Resources.Context.Provider;
using FileCompositions.Extensions.Host.Schema.Resources.Context.Provider.Implementations;
using FileCompositions.Extensions.Host.Schema.Resources.DirectoryLocation.Registrar.Implementations;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Registrar;
using FileCompositions.Extensions.Host.Schema.Resources.Registrar;
using FileCompositions.Extensions.Host.Schema.Resources.Registrar.Implementations;
using FileCompositions.Extensions.Host.StorageBackend.ActivationContext.Implementations;
using FileCompositions.Extensions.Host.StorageBackend.Container.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace FileCompositions.Extensions.Host.Schema.Builder.Implementations;

internal class HostResourceSchemaBuilder : IHostResourceSchemaBuilder
{
    private readonly IResourceSchemaStorageBackendRegistrar _storageBackendRegistrar;
    private readonly IHostResourceSchemaFileResourceRegistrar _fileRegistrar;

    private readonly IServiceCollection _settingServices;

    private readonly List<IResourceSettingDescriptor<string>> desicriptors = [];
    private readonly List<IDirectoryLocationDescriptor> resources = [];
    private IHostResourceSchemaResourcesContextProvider resourcesContextProvider;
    private HostStorageBackendContainer currentBackendContainer;

    public HostResourceSchemaBuilder(IResourceSchemaStorageBackendRegistrar storageBackendRegistrar,
        IHostResourceSchemaFileResourceRegistrar fileRegistrar, IServiceCollection settingServices)
    {
        _storageBackendRegistrar = storageBackendRegistrar;
        _fileRegistrar = fileRegistrar;
        _settingServices = settingServices;

        IServiceProvider currentServiceProvider = settingServices.BuildServiceProvider();
        currentBackendContainer = new(ref currentServiceProvider);
        var activationContext = new HostStorageBackendActivationContext(currentBackendContainer);
        _settingServices.AddSingleton(activationContext);

        resourcesContextProvider = new HostResourceSchemaResourcesContextProvider(new Dictionary<string, StorageAddress>()
        {
            ["Roaming"] = StorageAddress.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
        },
            ref desicriptors);
    }

    public IResourceSchemaBuilder ConfigureStorageBackends(Action<IResourceSchemaStorageBackendRegistrar> config)
    {
        config(_storageBackendRegistrar);

        IServiceProvider currentServiceProvider = _settingServices.BuildServiceProvider();
        currentBackendContainer = new(ref currentServiceProvider);
        var activationContext = new HostStorageBackendActivationContext(currentBackendContainer);
        _settingServices.AddSingleton(activationContext);

        return this;
    }
    public IHostResourceSchemaBuilder ConfigureRoots(Action<IHostResourceSchemaResourcesContextBuilder> config)
    {
        var builder = new HostResourceSchemaResourcesContextBuilder();
        config(builder);
        builder.UpdateProvider(ref resourcesContextProvider);
        return this;
    }
    public IHostResourceSchemaBuilder ConfigureResources(Action<IHostResourceSchemaResourcesRegistrar, IHostResourceSchemaResourcesContextProvider> config)
    {
        var directoryRegistrar = new HostResourceSchemaDirectoryLocationRegistrar(in _settingServices);
        var registrar = new HostResourceSchemaResourcesRegistrar(_fileRegistrar, directoryRegistrar);
        config(registrar, resourcesContextProvider);
        resources.AddRange(registrar.GetDirectoryDescriptors() ?? []);

        var activationContext = new HostStorageBackendActivationContext(currentBackendContainer);
        Initialize(registrar.GetDirectoryDescriptors() ?? [], activationContext);

        resourcesContextProvider.SetSettings(_settingServices.BuildServiceProvider());
        return this;
    }

    public IHostResourceSchema Build(ref IServiceProvider sp)
    {
        var container = new HostStorageBackendContainer(ref sp);
        var activationContext = new HostStorageBackendActivationContext(container);

        var schema = new HostResourceSchema(activationContext, resources);
        return schema;
    }

    private static void Initialize(IEnumerable<IDirectoryLocationDescriptor> descriptors, HostStorageBackendActivationContext currentActivationContext) =>
        Task.WhenAll(descriptors?
            .Select(async descriptor => await InitializeDirectory(descriptor, currentActivationContext)) ?? []);

    private static ValueTask InitializeDirectory(IDirectoryLocationDescriptor descriptor, HostStorageBackendActivationContext currentActivationContext) => descriptor switch
    {
        DirectoryLocationDescriptor => currentActivationContext.Activate(descriptor.BackendProvider).CreateAddress(descriptor.Address),
        OptionalDirectoryLocationDescriptor => ValueTask.CompletedTask,
        _ => throw new UnreachableException()
    };
}
