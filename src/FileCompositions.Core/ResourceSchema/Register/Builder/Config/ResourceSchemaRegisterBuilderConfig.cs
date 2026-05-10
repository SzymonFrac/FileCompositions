using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.ResourceSchema.Register.Builder.Config;

public delegate IResourceSchemaRegisterBuilder<TOwnership, TNecessity, TBackend> ResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity, TBackend>(IResourceSchemaRegisterBuilder<StrictDefinition, RequiredDefinition> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBackend : class, IStorageBackend;

public delegate IResourceSchemaRegisterBuilder<TOwnership, TNecessity> ResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity>(IResourceSchemaRegisterBuilder<StrictDefinition, RequiredDefinition> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;