using FileCompositions.Core.Directory.Quality;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Context.Factory.Implementations;

internal sealed class FileContextFactory : IFileContextFactory
{
    public IFileContext Create<TOwnership, TNecessity>(IDirectoryQuality<TOwnership, TNecessity> directory)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity =>
            new FileContext(directory.Context.FileSystem, directory.Address);
}
