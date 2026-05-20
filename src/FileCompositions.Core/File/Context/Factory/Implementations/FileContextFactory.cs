using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.Quality.Necessity;

namespace FileCompositions.Core.File.Context.Factory.Implementations;

internal class FileContextFactory : IFileContextFactory
{
    public IFileContext Create<TNecessity>(IDirectoryInterface<TNecessity> directory)
        where TNecessity : DefinitionNecessity =>
            new FileContext(directory.StorageBackend, directory.Address);
}
