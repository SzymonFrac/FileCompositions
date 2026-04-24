using FileCompositions.Core.Directory.Config;
using FileCompositions.Core.Directory.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.Directory.Registrar;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Backend.Implementations;
using FileCompositions.Extensions.Host.Schema.Directory.Register;
using FileCompositions.Extensions.Host.Schema.Directory.Register.Factory;
using FileCompositions.Extensions.Host.Schema.Directory.Registries;
using FileCompositions.Extensions.Host.Schema.Directory.Registries.Implementations;

namespace FileCompositions.Extensions.Host.Schema.Directory.Registrar.Implementations;

internal class HostResourceSchemaDirectoryRegistrar(IDirectoryDefinitionBuilderFactory builderFactory, IHostResourceSchemaDirectoryRegisterFactory registerFactory)
    : IHostResourceSchemaDirectoryRegistrar
{
    private readonly IDirectoryDefinitionBuilderFactory _builderFactory = builderFactory;
    private readonly IHostResourceSchemaDirectoryRegisterFactory _registerFactory = registerFactory;

    // Could use one delegate by using Multicast delegates
    private readonly List<HostResourceSchemaDirectoryRegister> _registries = [];

    public IHostResourceSchemaDirectoryRegistrar Store<TOwnership, TNecessity, TBackend>(ResourceSchemaDirectoryConfig<TOwnership, TNecessity> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend
    {
        var baseBuilder = _builderFactory.CreateDefault();
        var builder = config(baseBuilder);
        var descriptor = baseBuilder.BuildDescriptor();

        var register = _registerFactory.Create(descriptor);

        _registries.Add(register);
        return this;
    }

    public IHostResourceSchemaDirectoryRegistrar Store<TOwnership, TNecessity>(ResourceSchemaDirectoryConfig<TOwnership, TNecessity> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity =>
            Store<TOwnership, TNecessity, LocalDiskStorageBackend>(config);

    public IHostResourceSchemaDirectoryRegistries Build() =>
        new HostResourceSchemaDirectoryRegistries(_registries);

    IResourceSchemaDirectoryRegistrar IResourceSchemaDirectoryRegistrar.Store<TOwnership, TNecessity>(ResourceSchemaDirectoryConfig<TOwnership, TNecessity> config) => Store(config);
    IResourceSchemaDirectoryRegistrar IResourceSchemaDirectoryRegistrar.Store<TOwnership, TNecessity, TBackend>(ResourceSchemaDirectoryConfig<TOwnership, TNecessity> config) => Store(config);
}
