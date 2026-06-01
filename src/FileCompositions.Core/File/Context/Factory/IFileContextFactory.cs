using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Context.Factory;

internal interface IFileContextFactory
{
    IFileContext Create<TOwnership, TNecessity>(IDirectoryInterface<TOwnership, TNecessity> directory)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
