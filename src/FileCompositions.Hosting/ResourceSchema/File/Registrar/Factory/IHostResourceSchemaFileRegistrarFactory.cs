using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Hosting.ResourceSchema.File.Registrar.Factory;

internal interface IHostResourceSchemaFileRegistrarFactory
{
    IHostResourceSchemaFileRegistrar<TNecessity> Create<TOwnership, TNecessity>(DirectoryDefinitionKey key)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
