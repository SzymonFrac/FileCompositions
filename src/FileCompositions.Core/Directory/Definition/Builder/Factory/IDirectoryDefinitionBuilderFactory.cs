using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Addressing;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Definition.Builder.Factory;

public interface IDirectoryDefinitionBuilderFactory
{
    IDirectoryDefinitionBuilder<Ownership.Internal, Necessity.Required, TFileSystem> CreateDefault<TFileSystem>(Address address)
        where TFileSystem : class, IFileSystem;
    internal IDirectoryDefinitionBuilder<TOwnership, TNecessity, TFileSystem> Create<TOwnership, TNecessity, TFileSystem>(Address address)
        where TOwnership : Ownership
        where TNecessity : Necessity
        where TFileSystem : class, IFileSystem;
}
