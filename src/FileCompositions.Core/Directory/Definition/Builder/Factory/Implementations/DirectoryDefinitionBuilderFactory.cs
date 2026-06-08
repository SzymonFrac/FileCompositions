using FileCompositions.Core.Directory.Definition.Builder.Implementations;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Directory.Definition.Builder.Factory.Implementations;

internal sealed class DirectoryDefinitionBuilderFactory : IDirectoryDefinitionBuilderFactory
{
    public IDirectoryDefinitionBuilder<StrictDefinition, RequiredDefinition, TFileSystem> CreateDefault<TFileSystem>(FileSystemAddress address)
        where TFileSystem : class, IFileSystem =>
            new DirectoryDefinitionBuilder<StrictDefinition, RequiredDefinition, TFileSystem>(address);
    public IDirectoryDefinitionBuilder<TOwnership, TNecessity, TFileSystem> Create<TOwnership, TNecessity, TFileSystem>(FileSystemAddress address)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TFileSystem : class, IFileSystem =>
            new DirectoryDefinitionBuilder<TOwnership, TNecessity, TFileSystem>(address);
}
