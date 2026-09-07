using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality;

namespace FileCompositions.Hosting.ResourceSchema.File.Registrar.Factory;

internal interface IHostResourceSchemaFileRegistrarFactory
{
    IHostResourceSchemaFileRegistrar<TNecessity> Create<TOwnership, TNecessity>(DirectoryDefinitionKey key)
        where TOwnership : Ownership
        where TNecessity : Necessity;
}
