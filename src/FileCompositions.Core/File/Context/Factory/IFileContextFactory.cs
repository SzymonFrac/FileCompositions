using FileCompositions.Core.Directory.Quality;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Context.Factory;

internal interface IFileContextFactory
{
    IFileContext Create<TOwnership, TNecessity>(IDirectoryQuality<TOwnership, TNecessity> directory)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
