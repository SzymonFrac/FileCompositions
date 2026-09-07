using FileCompositions.Core.Directory.Definition.Config;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.ResourceSchema.Directory.Registrar;

public interface IResourceSchemaDirectoryRegistrar<TOwnership, TNecessity>
    where TOwnership : Ownership
    where TNecessity : Necessity
{
    IResourceSchemaDirectoryRegistrar<TDefOwnership, TDefNecessity> Define<TDefOwnership, TDefNecessity, TDefFileSystem>(DirectoryDefinitionConfig<TDefOwnership, TDefNecessity, TDefFileSystem> config)
        where TDefOwnership : Ownership
        where TDefNecessity : Necessity
        where TDefFileSystem : class, IFileSystem;
}