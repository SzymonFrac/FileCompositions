using FileCompositions.Core.Directory.Definition.Config;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.ResourceSchema.Register.Builder;

public interface IResourceSchemaRegisterBuilder<TOwnership, TNecessity, TBackend>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBackend : class, IStorageBackend
{
    IResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity, TDefBackend> Define<TDefOwnership, TDefNecessity, TDefBackend>(ResourceSchemaDirectoryConfig<TDefOwnership, TDefNecessity, TDefBackend> config)
        where TDefOwnership : DefinitionOwnership
        where TDefNecessity : DefinitionNecessity
        where TDefBackend : class, IStorageBackend;
}

public interface IResourceSchemaRegisterBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    IResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity, TDefBackend> Define<TDefOwnership, TDefNecessity, TDefBackend>(ResourceSchemaDirectoryConfig<TDefOwnership, TDefNecessity, TDefBackend> config)
        where TDefOwnership : DefinitionOwnership
        where TDefNecessity : DefinitionNecessity
        where TDefBackend : class, IStorageBackend;
    IResourceSchemaRegisterBuilder<TDefOwnership, TDefNecessity> Define<TDefOwnership, TDefNecessity>(ResourceSchemaDirectoryConfig<TDefOwnership, TDefNecessity> config)
        where TDefOwnership : DefinitionOwnership
        where TDefNecessity : DefinitionNecessity;
}