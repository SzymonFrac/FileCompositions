using FileCompositions.Core.Quality;

namespace FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory;

internal interface IHostResourceSchemaFileRegisterBuilderFactory
{
    IHostResourceSchemaFileRegisterBuilder Create<TInOwnership, TInNecessity>()
        where TInOwnership : Ownership
        where TInNecessity : Necessity;
}
