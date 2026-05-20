using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Registrar;
using FileCompositions.Extensions.Host.Schema.File.Register.Factory;
using FileCompositions.Extensions.Host.Schema.Register;

namespace FileCompositions.Extensions.Host.Schema.File.Registrar.Implementations;

internal class HostResourceSchemaFileRegistrar<TInOwnership, TInNecessity>(DirectoryDefinitionKey directoryKey, IHostResourceSchemaFileRegisterFactory<TInOwnership, TInNecessity, IDirectoryDefinition<TInOwnership, TInNecessity>> factory)
    : IHostResourceSchemaFileRegistrar<TInOwnership, TInNecessity>
        where TInOwnership : DefinitionOwnership
        where TInNecessity : DefinitionNecessity
{
    private readonly IHostResourceSchemaFileRegisterFactory<TInOwnership, TInNecessity, IDirectoryDefinition<TInOwnership, TInNecessity>> _factory = factory;
    private HostResourceSchemaRegister? register;

    public DirectoryDefinitionKey DirectoryKey { get; } = directoryKey;

    public void Store<TOwnership, TPlacement, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TPlacement> =>
            register += _factory.CreateFile<TOwnership, TPlacement, TDefinition, TDescriptor>(descriptor);

    public HostResourceSchemaRegister? Build() => register;


    DirectoryDefinitionKey IResourceSchemaFileRegistrar<TInOwnership, TInNecessity>.DirectoryKey => DirectoryKey;
}
