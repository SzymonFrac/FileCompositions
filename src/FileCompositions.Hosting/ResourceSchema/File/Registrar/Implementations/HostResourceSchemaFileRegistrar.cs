using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Registrar;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.Register;

namespace FileCompositions.Hosting.ResourceSchema.File.Registrar.Implementations;

internal sealed class HostResourceSchemaFileRegistrar<TInOwnership, TInNecessity>(DirectoryDefinitionKey directoryKey)
    : IHostResourceSchemaFileRegistrar<TInNecessity>
        where TInOwnership : DefinitionOwnership
        where TInNecessity : DefinitionNecessity
{
    private HostResourceSchemaRegister? register;

    public DirectoryDefinitionKey DirectoryKey { get; } = directoryKey;
    public IHostResourceSchemaFileRegisterBuilderFactory RegisterBuilderFactory { get; init; } = new HostResourceSchemaFileRegisterBuilderFactory();

    DirectoryDefinitionKey IResourceSchemaFileRegistrar<TInNecessity>.DirectoryKey => DirectoryKey;

    //public void Store<TOwnership, TPlacement, TDefinition, TDescriptor>(TDescriptor descriptor)
    //    where TOwnership : DefinitionOwnership
    //    where TPlacement : DefinitionPlacement
    //    where TDefinition : class, IFileDefinition<TOwnership, TPlacement>
    //    where TDescriptor : IFileDefinitionDescriptor<TOwnership, TPlacement, TDefinition> =>
    //        register += RegisterBuilderFactory
    //            .Create<TInOwnership, TInNecessity>()
    //            .Build<TOwnership, TPlacement, TDefinition, TDescriptor>(descriptor);

    //public void Store<TOwnership, TPlacement, TDefinition, TDescriptor>(TDescriptor descriptor, IHostResourceSchemaFileRegisterBuilderFactory factory)
    //    where TOwnership : DefinitionOwnership
    //    where TPlacement : DefinitionPlacement
    //    where TDefinition : class, IFileDefinition<TOwnership, TPlacement>
    //    where TDescriptor : IFileDefinitionDescriptor<TOwnership, TPlacement, TDefinition> =>
    //        register += factory
    //            .Create<TInOwnership, TInNecessity>()
    //            .Build<TOwnership, TPlacement, TDefinition, TDescriptor>(descriptor);

    public void Define<TOwnership, TPlacement, TDefinition>(DirectoryDefinitionKey directoryKey, FileDefinitionKey fileKey, FileDefinitionRequestDescriptor<TOwnership, TPlacement, TDefinition> descriptor)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement> =>
            register += RegisterBuilderFactory
                .Create<TInOwnership, TInNecessity>()
                .Build(directoryKey, fileKey, descriptor);

    public void Define<TOwnership, TPlacement, TDefinition>(DirectoryDefinitionKey directoryKey, FileDefinitionKey fileKey, FileDefinitionRequestDescriptor<TOwnership, TPlacement, TDefinition> descriptor, IHostResourceSchemaFileRegisterBuilderFactory factory)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement> =>
            register += factory
                .Create<TInOwnership, TInNecessity>()
                .Build(directoryKey, fileKey, descriptor);

    public HostResourceSchemaRegister? Build() => register;

    HostResourceSchemaRegister? IHostResourceSchemaFileRegistrar<TInNecessity>.Build()
    {
        return Build();
    }
}
