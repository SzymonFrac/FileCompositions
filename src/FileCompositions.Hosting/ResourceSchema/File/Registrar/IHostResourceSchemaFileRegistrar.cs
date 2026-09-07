using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using FileCompositions.Core.ResourceSchema.File.Registrar;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory;
using FileCompositions.Hosting.ResourceSchema.Register;

namespace FileCompositions.Hosting.ResourceSchema.File.Registrar;

public interface IHostResourceSchemaFileRegistrar<TInNecessity> : IResourceSchemaFileRegistrar<TInNecessity>
    where TInNecessity : Necessity
{
    internal void Define<TOwnership, TPlacement, TDefinition>(ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition> request, IHostResourceSchemaFileRegisterBuilderFactory factory)
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>;

    internal HostResourceSchemaRegister? Build();
}
