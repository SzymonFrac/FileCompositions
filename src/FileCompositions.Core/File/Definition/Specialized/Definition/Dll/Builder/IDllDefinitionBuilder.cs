using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Resource.Specialized.Dll.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Builder;

internal interface IDllDefinitionBuilder<TOwnership, TNecessity> : IFileDefinitionBuilder<TOwnership, TNecessity>, IDllResourceBuilder
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    new IDllDefinitionBuilder<TOwnership, TNecessity> WithName(string name);

    new internal IDllDefinition<TOwnership, TNecessity> Build(IDirectoryLocation directory);
}
