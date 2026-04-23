using FileCompositions.Core.Directory.Definition.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Config;

public delegate IDirectoryDefinitionBuilder<TOwnership, TNecessity> ResourceSchemaDirectoryConfig<TOwnership, TNecessity>(IDirectoryDefinitionBuilder<StrictDefinition, RequiredDefinition> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;

public delegate IDirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend> ResourceSchemaDirectoryConfig<TOwnership, TNecessity, TBackend>(IDirectoryDefinitionBuilder<StrictDefinition, RequiredDefinition> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBackend : class, IStorageBackend;
