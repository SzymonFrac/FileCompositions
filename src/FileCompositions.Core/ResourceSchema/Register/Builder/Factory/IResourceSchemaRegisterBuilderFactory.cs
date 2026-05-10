using FileCompositions.Core.Directory.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.ResourceSchema.Register.Builder.Factory;

internal interface IResourceSchemaRegisterBuilderFactory
{
    IResourceSchemaRegisterBuilder<StrictDefinition, RequiredDefinition> CreateDefault(IDirectoryDefinitionBuilderFactory factory);
    IResourceSchemaRegisterBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>(IDirectoryDefinitionBuilderFactory factory)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
