using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.ResourceSchema.Directory.Registrar.Factory;

namespace FileCompositions.Hosting.ResourceSchema.Directory.Registrar.Factory;

internal interface IHostResourceSchemaDirectoryRegistrarFactory : IResourceSchemaDirectoryRegistrarFactory
{
    new IHostResourceSchemaDirectoryRegistrar<StrictDefinition, RequiredDefinition> Create();
    new IHostResourceSchemaDirectoryRegistrar<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
