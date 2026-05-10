using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.Directory.Registrar;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Extensions.Host.Schema.Register;
using FileCompositions.Extensions.Host.Schema.Register.Config;

namespace FileCompositions.Extensions.Host.Schema.Directory.Registrar;

public interface IHostResourceSchemaDirectoryRegistrar : IResourceSchemaDirectoryRegistrar
{
    IHostResourceSchemaDirectoryRegistrar Store<TOwnership, TNecessity, TBackend>(HostResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity, TBackend> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend;
    IHostResourceSchemaDirectoryRegistrar Store<TOwnership, TNecessity>(HostResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;

    internal HostResourceSchemaRegister? Build();
}