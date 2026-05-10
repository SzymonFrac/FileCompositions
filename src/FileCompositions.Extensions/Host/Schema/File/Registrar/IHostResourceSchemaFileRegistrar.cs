using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.File.Registrar;
using FileCompositions.Extensions.Host.Schema.Register;

namespace FileCompositions.Extensions.Host.Schema.File.Registrar;

public interface IHostResourceSchemaFileRegistrar<TInOwnership, TInNecessity> : IResourceSchemaFileRegistrar<TInOwnership, TInNecessity>
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
{
    internal HostResourceSchemaRegister? Build();
}
