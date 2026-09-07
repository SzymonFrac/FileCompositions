using FileCompositions.Core.Directory.Definition.Builder;
using FileCompositions.Core.Directory.Definition.Builder.Factory;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Definition.Config;

public delegate IDirectoryDefinitionBuilder<TOwnership, TNecessity, TFileSystem> DirectoryDefinitionConfig<TOwnership, TNecessity, TFileSystem>(IDirectoryDefinitionBuilderFactory config)
    where TOwnership : Ownership
    where TNecessity : Necessity
    where TFileSystem : class, IFileSystem;
