using FileCompositions.Core.Directory.Definition.Builder.Factory.Implementations;
using FileCompositions.Core.ResourceSchema.Builder;
using FileCompositions.Core.ResourceSchema.File.Definition.Registrar;
using FileCompositions.Core.ResourceSchema.StorageBackend.Registrar;
using FileCompositions.Core.Setting.Descriptor;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Extensions.Host.Schema.Directory.Register.Factory.Implementations;
using FileCompositions.Extensions.Host.Schema.Directory.Registrar;
using FileCompositions.Extensions.Host.Schema.Directory.Registrar.Implementations;
using FileCompositions.Extensions.Host.Schema.Implementation;
using FileCompositions.Extensions.Host.Schema.Resources.Context.Builder;
using FileCompositions.Extensions.Host.Schema.Resources.Context.Builder.Implementations;
using FileCompositions.Extensions.Host.Schema.Resources.Context.Provider;
using FileCompositions.Extensions.Host.Schema.Resources.Context.Provider.Implementations;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Registrar;
using FileCompositions.Extensions.Host.StorageBackend.Registrar.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Builder.Implementations;

internal class HostResourceSchemaBuilder : IHostResourceSchemaBuilder
{
    private readonly IHostResourceSchemaFileResourceRegistrar _fileRegistrar;

    private readonly HostStorageBackendRegistrar _storageBackendRegistrar;
    private readonly HostResourceSchemaDirectoryRegistrar _directoryRegistrar =
        new(new DirectoryDefinitionBuilderFactory(), new HostResourceSchemaDirectoryRegisterFactory());




    private readonly List<IResourceSettingDescriptor<string>> desicriptors = [];
    //private readonly List<IDirectoryLocationDescriptor> resources = [];
    private IHostResourceSchemaResourcesContextProvider resourcesContextProvider;

    public HostResourceSchemaBuilder(IHostResourceSchemaFileResourceRegistrar fileRegistrar)
    {
        _storageBackendRegistrar = new();
        _fileRegistrar = fileRegistrar;

        // Settings...
        resourcesContextProvider = new HostResourceSchemaResourcesContextProvider(new Dictionary<string, StorageAddress>()
        {
            ["Roaming"] = StorageAddress.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
        },
            ref desicriptors);
    }


    public IHostResourceSchemaBuilder ConfigureStorageBackends(Action<IResourceSchemaStorageBackendRegistrar> config)
    {
        config(_storageBackendRegistrar);
        return this;
    }

    public IHostResourceSchemaBuilder ConfigureDefinitions(Action<IResourceSchemaFileDefinitionRegistrar> config)
    {
        throw new NotImplementedException();
    }

    // Settings...
    public IHostResourceSchemaBuilder ConfigureRoots(Action<IHostResourceSchemaResourcesContextBuilder> config)
    {
        var builder = new HostResourceSchemaResourcesContextBuilder();
        config(builder);
        builder.UpdateProvider(ref resourcesContextProvider);
        return this;
    }
    public IHostResourceSchemaBuilder ConfigureDirectories(Action<IHostResourceSchemaDirectoryRegistrar> config)
    {
        config(_directoryRegistrar);
        return this;
    }

    public IHostResourceSchema Build(in IServiceCollection services)
    {
        _storageBackendRegistrar.Register(in services);

        var directoryRegistries = _directoryRegistrar.Build();

        var schema = new HostResourceSchema(directoryRegistries);
        return schema;
    }

    IResourceSchemaBuilder IResourceSchemaBuilder.ConfigureStorageBackends(Action<IResourceSchemaStorageBackendRegistrar> config) =>
        ConfigureStorageBackends(config);
    IResourceSchemaBuilder IResourceSchemaBuilder.ConfigureDefinitions(Action<IResourceSchemaFileDefinitionRegistrar> config) =>
        ConfigureDefinitions(config);

    // Should exist in .Core, requireds are ensured, optionals are valid in both states
    // Although, the schema probably should still ensure or initialize it all

    //private static void Initialize(IEnumerable<IDirectoryLocationDescriptor> descriptors, HostStorageBackendActivationContext currentActivationContext) =>
    //    Task.WhenAll(descriptors?
    //        .Select(async descriptor => await InitializeDirectory(descriptor, currentActivationContext)) ?? []);

    //private static ValueTask InitializeDirectory(IDirectoryLocationDescriptor descriptor, HostStorageBackendActivationContext currentActivationContext) => descriptor switch
    //{
    //    DirectoryLocationDescriptor => currentActivationContext.Activate(descriptor.BackendProvider).CreateAddress(descriptor.Address),
    //    OptionalDirectoryLocationDescriptor => ValueTask.CompletedTask,
    //    _ => throw new UnreachableException()
    //};
}
