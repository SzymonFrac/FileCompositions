using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Definition.Builder.Factory;

public interface IDirectoryDefinitionBuilderFactory
{
    IDirectoryDefinitionBuilder<Ownership.Internal, Necessity.Required, TFileSystem> CreateDefault<TFileSystem>(FileSystemAddress address)
        where TFileSystem : class, IFileSystem;
    internal IDirectoryDefinitionBuilder<TOwnership, TNecessity, TFileSystem> Create<TOwnership, TNecessity, TFileSystem>(FileSystemAddress address)
        where TOwnership : Ownership
        where TNecessity : Necessity
        where TFileSystem : class, IFileSystem;
}
