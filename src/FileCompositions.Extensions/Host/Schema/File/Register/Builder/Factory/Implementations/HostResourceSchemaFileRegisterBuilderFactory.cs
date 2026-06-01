using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Extensions.Host.Schema.File.Register.Builder.Implementations;

namespace FileCompositions.Extensions.Host.Schema.File.Register.Builder.Factory.Implementations;

internal class HostResourceSchemaFileRegisterBuilderFactory : IHostResourceSchemaFileRegisterBuilderFactory
{
    public IHostResourceSchemaFileRegisterBuilder Create<TInOwnership, TInNecessity>()
        where TInOwnership : DefinitionOwnership
        where TInNecessity : DefinitionNecessity =>
            new HostResourceSchemaFileRegisterBuilder<TInOwnership, TInNecessity>();
}
