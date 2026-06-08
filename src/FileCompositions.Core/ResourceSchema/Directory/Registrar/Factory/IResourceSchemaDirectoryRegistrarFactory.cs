using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.ResourceSchema.Directory.Registrar.Factory;

internal interface IResourceSchemaDirectoryRegistrarFactory
{
    IResourceSchemaDirectoryRegistrar<StrictDefinition, RequiredDefinition> Create();
    IResourceSchemaDirectoryRegistrar<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
