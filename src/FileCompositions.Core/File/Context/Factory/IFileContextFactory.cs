using FileCompositions.Core.Directory.Quality;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Context.Factory;

internal interface IFileContextFactory
{
    IFileContext Create<TOwnership, TNecessity>(IDirectoryQuality<TOwnership, TNecessity> directory)
        where TOwnership : Ownership
        where TNecessity : Necessity;
}
