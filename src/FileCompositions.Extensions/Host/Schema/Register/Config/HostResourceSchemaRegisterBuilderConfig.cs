using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Extensions.Host.Schema.Register.Builder;

namespace FileCompositions.Extensions.Host.Schema.Register.Config;

public delegate IHostResourceSchemaRegisterBuilder<TOwnership, TNecessity, TBackend> HostResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity, TBackend>(IHostResourceSchemaRegisterBuilder<StrictDefinition, RequiredDefinition> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBackend : class, IStorageBackend;

public delegate IHostResourceSchemaRegisterBuilder<TOwnership, TNecessity> HostResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity>(IHostResourceSchemaRegisterBuilder<StrictDefinition, RequiredDefinition> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;
