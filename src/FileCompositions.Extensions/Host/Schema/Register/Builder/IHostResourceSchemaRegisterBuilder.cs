using FileCompositions.Core.Directory.Definition.Config;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.Register.Builder;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Extensions.Host.Schema.File.Registrar;

namespace FileCompositions.Extensions.Host.Schema.Register.Builder;

public interface IHostResourceSchemaRegisterBuilder<TOwnership, TNecessity, TBackend> : IResourceSchemaRegisterBuilder<TOwnership, TNecessity, TBackend>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBackend : class, IStorageBackend
{
    new IHostResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity, TDefBackend> Define<TDefOwnership, TDefNecessity, TDefBackend>(ResourceSchemaDirectoryConfig<TDefOwnership, TDefNecessity, TDefBackend> config)
        where TDefOwnership : DefinitionOwnership
        where TDefNecessity : DefinitionNecessity
        where TDefBackend : class, IStorageBackend;
    IHostResourceSchemaRegisterBuilder<TOwnership, TNecessity, TBackend> WithFiles(Action<IHostResourceSchemaFileRegistrar<TNecessity>> config);

    internal HostResourceSchemaRegister? Build();
}

public interface IHostResourceSchemaRegisterBuilder<TOwnership, TNecessity> : IResourceSchemaRegisterBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    new IHostResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity, TDefBackend> Define<TDefOwnership, TDefNecessity, TDefBackend>(ResourceSchemaDirectoryConfig<TDefOwnership, TDefNecessity, TDefBackend> config)
        where TDefOwnership : DefinitionOwnership
        where TDefNecessity : DefinitionNecessity
        where TDefBackend : class, IStorageBackend;
    new IHostResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity> Define<TDefOwnership, TDefNecessity>(ResourceSchemaDirectoryConfig<TDefOwnership, TDefNecessity> config)
        where TDefOwnership : DefinitionOwnership
        where TDefNecessity : DefinitionNecessity;
    IHostResourceSchemaRegisterBuilder<TOwnership, TNecessity> WithFiles(Action<IHostResourceSchemaFileRegistrar<TNecessity>> config);

    internal HostResourceSchemaRegister? Build();
}