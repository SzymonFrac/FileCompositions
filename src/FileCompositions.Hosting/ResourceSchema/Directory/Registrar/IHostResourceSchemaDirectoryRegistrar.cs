using FileCompositions.Core.Directory.Definition.Config;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.Directory.Registrar;
using FileCompositions.Hosting.ResourceSchema.File.Registrar;
using FileCompositions.Hosting.ResourceSchema.Register;

namespace FileCompositions.Hosting.ResourceSchema.Directory.Registrar;

public interface IHostResourceSchemaDirectoryRegistrar<TOwnership, TNecessity> : IResourceSchemaDirectoryRegistrar<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    new IHostResourceSchemaDirectoryRegistrar<TDefOwnership, TDefNecessity> Define<TDefOwnership, TDefNecessity, TDefFileSystem>(DirectoryDefinitionConfig<TDefOwnership, TDefNecessity, TDefFileSystem> config)
        where TDefOwnership : DefinitionOwnership
        where TDefNecessity : DefinitionNecessity
        where TDefFileSystem : class, IFileSystem;
    IHostResourceSchemaDirectoryRegistrar<TOwnership, TNecessity> WithFiles(Action<IHostResourceSchemaFileRegistrar<TNecessity>> config);

    internal HostResourceSchemaRegister? Build();
}