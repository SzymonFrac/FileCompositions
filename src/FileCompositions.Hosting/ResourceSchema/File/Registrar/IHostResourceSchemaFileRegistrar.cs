using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using FileCompositions.Core.ResourceSchema.File.Registrar;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory;
using FileCompositions.Hosting.ResourceSchema.Register;

namespace FileCompositions.Hosting.ResourceSchema.File.Registrar;

public interface IHostResourceSchemaFileRegistrar<TInNecessity> : IResourceSchemaFileRegistrar<TInNecessity>
    where TInNecessity : DefinitionNecessity
{
    internal void Define<TOwnership, TPlacement, TDefinition>(ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition> request, IHostResourceSchemaFileRegisterBuilderFactory factory)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>;

    internal HostResourceSchemaRegister? Build();
}
