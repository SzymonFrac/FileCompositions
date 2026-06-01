using FileCompositions.Core.Directory.Definition.Builder.Factory;
using FileCompositions.Core.Directory.Definition.Config;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.Register.Builder;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Extensions.Host.Schema.File.Registrar;
using FileCompositions.Extensions.Host.Schema.Register.Factory.Implementations;

namespace FileCompositions.Extensions.Host.Schema.Register.Builder.Implementations;

file sealed class HostResourceSchemaRegisterBuilder<TOwnership, TNecessity, TBackend>(IDirectoryDefinitionBuilderFactory factory, ResourceSchemaDirectoryConfig<TOwnership, TNecessity, TBackend> config)
    : IHostResourceSchemaRegisterBuilder<TOwnership, TNecessity, TBackend>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend
{
    private readonly IDirectoryDefinitionBuilderFactory _factory = factory;

    private readonly ResourceSchemaDirectoryConfig<TOwnership, TNecessity, TBackend> _config = config;
    private Action<IHostResourceSchemaFileRegistrar<TNecessity>>? fileConfig;

    public IHostResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity, TDefBackend> Define<TDefOwnership, TDefNecessity, TDefBackend>(ResourceSchemaDirectoryConfig<TDefOwnership, TDefNecessity, TDefBackend> config)
        where TDefOwnership : DefinitionOwnership
        where TDefNecessity : DefinitionNecessity
        where TDefBackend : class, IStorageBackend =>
            new HostResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity, TDefBackend>(_factory, config);

    public IHostResourceSchemaRegisterBuilder<TOwnership, TNecessity, TBackend> WithFiles(Action<IHostResourceSchemaFileRegistrar<TNecessity>> config)
    {
        fileConfig = config;
        return this;
    }
    
    public HostResourceSchemaRegister? Build()
    {
        var factory = new HostResourceSchemaRegisterFactory();

        if (_config is null)
            return default;

        var baseBuilder = _factory.CreateDefault();
        var builder = _config(baseBuilder);
        var descriptor = builder.BuildDescriptor();

        var register = factory.Create(descriptor, fileConfig);
        return register;
    }


    IResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity, TDefBackend> IResourceSchemaRegisterBuilder<TOwnership, TNecessity, TBackend>.Define<TDefOwnership, TDefNecessity, TDefBackend>(ResourceSchemaDirectoryConfig<TDefOwnership, TDefNecessity, TDefBackend> config) =>
        Define(config);
}

internal class HostResourceSchemaRegisterBuilder<TOwnership, TNecessity> : IHostResourceSchemaRegisterBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    private readonly IDirectoryDefinitionBuilderFactory _factory;

    private readonly ResourceSchemaDirectoryConfig<TOwnership, TNecessity>? _config;
    private Action<IHostResourceSchemaFileRegistrar<TNecessity>>? fileConfig;

    public HostResourceSchemaRegisterBuilder(IDirectoryDefinitionBuilderFactory factory) => _factory = factory;
    private HostResourceSchemaRegisterBuilder(IDirectoryDefinitionBuilderFactory factory, ResourceSchemaDirectoryConfig<TOwnership, TNecessity> config) =>
        (_factory, _config) = (factory, config);

    public IHostResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity, TDefBackend> Define<TDefOwnership, TDefNecessity, TDefBackend>(ResourceSchemaDirectoryConfig<TDefOwnership, TDefNecessity, TDefBackend> config)
        where TDefOwnership : DefinitionOwnership
        where TDefNecessity : DefinitionNecessity
        where TDefBackend : class, IStorageBackend =>
            new HostResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity, TDefBackend>(_factory, config);

    public IHostResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity> Define<TDefOwnership, TDefNecessity>(ResourceSchemaDirectoryConfig<TDefOwnership, TDefNecessity> config)
        where TDefOwnership : DefinitionOwnership
        where TDefNecessity : DefinitionNecessity =>
            new HostResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity>(_factory, config);

    public IHostResourceSchemaRegisterBuilder<TOwnership, TNecessity> WithFiles(Action<IHostResourceSchemaFileRegistrar<TNecessity>> config)
    {
        fileConfig = config;
        return this;
    }

    public HostResourceSchemaRegister? Build()
    {
        if (_config is null)
            return default;

        var factory = new HostResourceSchemaRegisterFactory();

        var baseBuilder = _factory.CreateDefault();
        var builder = _config(baseBuilder);
        var descriptor = builder.BuildDescriptor();

        var register = factory.Create(descriptor, fileConfig);
        return register;
    }


    IResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity, TDefBackend> IResourceSchemaRegisterBuilder<TOwnership, TNecessity>.Define<TDefOwnership, TDefNecessity, TDefBackend>(ResourceSchemaDirectoryConfig<TDefOwnership, TDefNecessity, TDefBackend> config) =>
        Define(config);
    IResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity> IResourceSchemaRegisterBuilder<TOwnership, TNecessity>.Define<TDefOwnership, TDefNecessity>(ResourceSchemaDirectoryConfig<TDefOwnership, TDefNecessity> config) =>
        Define(config);
}
