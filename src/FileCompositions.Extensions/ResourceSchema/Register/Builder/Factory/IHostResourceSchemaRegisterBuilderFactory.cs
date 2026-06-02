using FileCompositions.Core.Directory.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.ResourceSchema.Register.Builder.Factory;

namespace FileCompositions.Hosting.ResourceSchema.Register.Builder.Factory;

internal interface IHostResourceSchemaRegisterBuilderFactory : IResourceSchemaRegisterBuilderFactory
{
    new IHostResourceSchemaRegisterBuilder<StrictDefinition, RequiredDefinition> CreateDefault(IDirectoryDefinitionBuilderFactory factory);
    new IHostResourceSchemaRegisterBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>(IDirectoryDefinitionBuilderFactory factory)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
