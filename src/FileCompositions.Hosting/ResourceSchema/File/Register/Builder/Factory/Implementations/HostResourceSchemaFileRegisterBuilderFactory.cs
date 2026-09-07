using FileCompositions.Core.Quality;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Implementations;

namespace FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory.Implementations;

internal sealed class HostResourceSchemaFileRegisterBuilderFactory : IHostResourceSchemaFileRegisterBuilderFactory
{
    public IHostResourceSchemaFileRegisterBuilder Create<TInOwnership, TInNecessity>()
        where TInOwnership : Ownership
        where TInNecessity : Necessity =>
            new HostResourceSchemaFileRegisterBuilder<TInOwnership, TInNecessity>();
}
