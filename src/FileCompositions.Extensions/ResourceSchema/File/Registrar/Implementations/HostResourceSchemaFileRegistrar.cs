using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Registrar;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory;
using FileCompositions.Hosting.ResourceSchema.Register;

namespace FileCompositions.Hosting.ResourceSchema.File.Registrar.Implementations;

internal sealed class HostResourceSchemaFileRegistrar<TInOwnership, TInNecessity>(DirectoryDefinitionKey directoryKey, IHostResourceSchemaFileRegisterBuilderFactory factory)
    : IHostResourceSchemaFileRegistrar<TInNecessity>
        where TInOwnership : DefinitionOwnership
        where TInNecessity : DefinitionNecessity
{
    private readonly IHostResourceSchemaFileRegisterBuilderFactory _factory = factory;
    private HostResourceSchemaRegister? register;

    public DirectoryDefinitionKey DirectoryKey { get; } = directoryKey;

    public void Store<TOwnership, TPlacement, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TPlacement> =>
            register += _factory
                .Create<TInOwnership, TInNecessity>()
                .Build<TOwnership, TPlacement, TDefinition, TDescriptor>(descriptor);

    public void Store<TOwnership, TPlacement, TDefinition, TDescriptor>(TDescriptor descriptor, IHostResourceSchemaFileRegisterBuilderFactory factory)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TPlacement> =>
            register += factory
                .Create<TInOwnership, TInNecessity>()
                .Build<TOwnership, TPlacement, TDefinition, TDescriptor>(descriptor);

    public HostResourceSchemaRegister? Build() => register;

    DirectoryDefinitionKey IResourceSchemaFileRegistrar<TInNecessity>.DirectoryKey => DirectoryKey;
}
