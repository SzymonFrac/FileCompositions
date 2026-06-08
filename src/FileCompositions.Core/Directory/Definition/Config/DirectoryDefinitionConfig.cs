using FileCompositions.Core.Directory.Definition.Builder;
using FileCompositions.Core.Directory.Definition.Builder.Factory;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Definition.Config;

public delegate IDirectoryDefinitionBuilder<TOwnership, TNecessity, TFileSystem> DirectoryDefinitionConfig<TOwnership, TNecessity, TFileSystem>(IDirectoryDefinitionBuilderFactory config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TFileSystem : class, IFileSystem;
