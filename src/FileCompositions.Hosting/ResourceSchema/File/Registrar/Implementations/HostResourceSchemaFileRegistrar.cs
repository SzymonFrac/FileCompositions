using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using FileCompositions.Core.ResourceSchema.File.Registrar;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.Register;

namespace FileCompositions.Hosting.ResourceSchema.File.Registrar.Implementations;

internal sealed class HostResourceSchemaFileRegistrar<TInOwnership, TInNecessity>(DirectoryDefinitionKey directoryKey)
    : IHostResourceSchemaFileRegistrar<TInNecessity>
        where TInOwnership : Ownership
        where TInNecessity : Necessity
{
    private HostResourceSchemaRegister? register;

    public DirectoryDefinitionKey DirectoryKey { get; } = directoryKey;
    public IHostResourceSchemaFileRegisterBuilderFactory RegisterBuilderFactory { get; init; } = new HostResourceSchemaFileRegisterBuilderFactory();

    DirectoryDefinitionKey IResourceSchemaFileRegistrar<TInNecessity>.DirectoryKey => DirectoryKey;

    public void Define<TOwnership, TPlacement, TDefinition>(ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition> request)
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement> =>
            register += RegisterBuilderFactory
                .Create<TInOwnership, TInNecessity>()
                .Build(request);

    public void Define<TOwnership, TPlacement, TDefinition>(ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition> request, IHostResourceSchemaFileRegisterBuilderFactory factory)
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement> =>
            register += factory
                .Create<TInOwnership, TInNecessity>()
                .Build(request);

    public HostResourceSchemaRegister? Build() => register;

    HostResourceSchemaRegister? IHostResourceSchemaFileRegistrar<TInNecessity>.Build()
    {
        return Build();
    }
}
