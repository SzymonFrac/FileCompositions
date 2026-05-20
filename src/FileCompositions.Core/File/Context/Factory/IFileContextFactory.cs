using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.Quality.Necessity;

namespace FileCompositions.Core.File.Context.Factory;

internal interface IFileContextFactory
{
    IFileContext Create<TNecessity>(IDirectoryInterface<TNecessity> directory)
        where TNecessity : DefinitionNecessity;
}
