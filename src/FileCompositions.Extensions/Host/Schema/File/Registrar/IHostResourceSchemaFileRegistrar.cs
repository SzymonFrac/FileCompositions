using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Registrar;
using FileCompositions.Extensions.Host.Schema.File.Register.Builder.Factory;
using FileCompositions.Extensions.Host.Schema.Register;

namespace FileCompositions.Extensions.Host.Schema.File.Registrar;

public interface IHostResourceSchemaFileRegistrar<TInNecessity> : IResourceSchemaFileRegistrar<TInNecessity>
    where TInNecessity : DefinitionNecessity
{
    internal void Store<TOwnership, TPlacement, TDefinition, TDescriptor>(TDescriptor descriptor, IHostResourceSchemaFileRegisterBuilderFactory factory)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TPlacement>;

    internal HostResourceSchemaRegister? Build();
}
