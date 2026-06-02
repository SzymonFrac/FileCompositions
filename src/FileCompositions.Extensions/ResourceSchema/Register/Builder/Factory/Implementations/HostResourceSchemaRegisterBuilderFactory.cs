using FileCompositions.Core.Directory.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.ResourceSchema.Register.Builder;
using FileCompositions.Core.ResourceSchema.Register.Builder.Factory;
using FileCompositions.Hosting.ResourceSchema.Register.Builder.Implementations;

namespace FileCompositions.Hosting.ResourceSchema.Register.Builder.Factory.Implementations;

internal sealed class HostResourceSchemaRegisterBuilderFactory : IHostResourceSchemaRegisterBuilderFactory
{
    public IHostResourceSchemaRegisterBuilder<StrictDefinition, RequiredDefinition> CreateDefault(IDirectoryDefinitionBuilderFactory factory) =>
        new HostResourceSchemaRegisterBuilder<StrictDefinition, RequiredDefinition>(factory);
    public IHostResourceSchemaRegisterBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>(IDirectoryDefinitionBuilderFactory factory)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity =>
            new HostResourceSchemaRegisterBuilder<TOwnership, TNecessity>(factory);

    IResourceSchemaRegisterBuilder<StrictDefinition, RequiredDefinition> IResourceSchemaRegisterBuilderFactory.CreateDefault(IDirectoryDefinitionBuilderFactory factory) =>
        CreateDefault(factory);
    IResourceSchemaRegisterBuilder<TOwnership, TNecessity> IResourceSchemaRegisterBuilderFactory.Create<TOwnership, TNecessity>(IDirectoryDefinitionBuilderFactory factory) =>
        Create<TOwnership, TNecessity>(factory);
}
