using FileCompositions.Core.Directory.Definition.Builder.Implementations;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Definition.Builder.Factory.Implementations;

internal sealed class DirectoryDefinitionBuilderFactory : IDirectoryDefinitionBuilderFactory
{
    public IDirectoryDefinitionBuilder<Ownership.Internal, Necessity.Required, TFileSystem> CreateDefault<TFileSystem>(FileSystemAddress address)
        where TFileSystem : class, IFileSystem =>
            new DirectoryDefinitionBuilder<Ownership.Internal, Necessity.Required, TFileSystem>(address);
    public IDirectoryDefinitionBuilder<TOwnership, TNecessity, TFileSystem> Create<TOwnership, TNecessity, TFileSystem>(FileSystemAddress address)
        where TOwnership : Ownership
        where TNecessity : Necessity
        where TFileSystem : class, IFileSystem =>
            new DirectoryDefinitionBuilder<TOwnership, TNecessity, TFileSystem>(address);
}
