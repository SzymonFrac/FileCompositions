using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Hosting.ResourceSchema.Directory.Registrar;

namespace FileCompositions.Hosting.ResourceSchema.Register.Config;

public delegate IHostResourceSchemaDirectoryRegistrar<TOwnership, TNecessity> HostResourceSchemaRegisterBuilderConfig<TOwnership, TNecessity>(IHostResourceSchemaDirectoryRegistrar<StrictDefinition, RequiredDefinition> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;
