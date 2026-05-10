using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.File.Registrar;
using FileCompositions.Extensions.Host.Schema.File.Register.Factory;
using FileCompositions.Extensions.Host.Schema.Register;

namespace FileCompositions.Extensions.Host.Schema.File.Registrar.Implementations;

internal class HostResourceSchemaFileRegistrar<TInOwnership, TInNecessity>(DirectoryDefinitionKey directoryKey, IHostResourceSchemaFileRegisterFactory<IDirectoryDefinition<TInOwnership, TInNecessity>> factory)
    : IHostResourceSchemaFileRegistrar<TInOwnership, TInNecessity>
        where TInOwnership : DefinitionOwnership
        where TInNecessity : DefinitionNecessity
{
    private readonly IHostResourceSchemaFileRegisterFactory<IDirectoryDefinition<TInOwnership, TInNecessity>> _factory = factory;
    private HostResourceSchemaRegister? register;

    public DirectoryDefinitionKey DirectoryKey { get; } = directoryKey;

    public void Store<TOwnership, TNecessity, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDefinition : class, IFileDefinition<TOwnership, TNecessity>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TNecessity> =>
            register += _factory.CreateFile<TOwnership, TNecessity, TDefinition, TDescriptor>(descriptor);

    public HostResourceSchemaRegister? Build() => register;


    DirectoryDefinitionKey IResourceSchemaFileRegistrar<TInOwnership, TInNecessity>.DirectoryKey => DirectoryKey;
}
