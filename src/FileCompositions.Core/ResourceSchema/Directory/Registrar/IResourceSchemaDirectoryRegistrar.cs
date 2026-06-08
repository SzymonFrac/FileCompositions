using FileCompositions.Core.Directory.Definition.Config;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.ResourceSchema.Directory.Registrar;

public interface IResourceSchemaDirectoryRegistrar<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    IResourceSchemaDirectoryRegistrar<TDefOwnership, TDefNecessity> Define<TDefOwnership, TDefNecessity, TDefFileSystem>(DirectoryDefinitionConfig<TDefOwnership, TDefNecessity, TDefFileSystem> config)
        where TDefOwnership : DefinitionOwnership
        where TDefNecessity : DefinitionNecessity
        where TDefFileSystem : class, IFileSystem;
}