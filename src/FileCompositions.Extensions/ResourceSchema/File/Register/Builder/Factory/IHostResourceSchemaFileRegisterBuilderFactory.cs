using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory;

internal interface IHostResourceSchemaFileRegisterBuilderFactory
{
    IHostResourceSchemaFileRegisterBuilder Create<TInOwnership, TInNecessity>()
        where TInOwnership : DefinitionOwnership
        where TInNecessity : DefinitionNecessity;
}
