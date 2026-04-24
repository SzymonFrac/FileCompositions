using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Resource.Specialized.Dll;
using FileCompositions.Core.File.Resource.Specialized.Dll.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Specialized.Dll;

public interface IDllDefinition<TOwnership, TNecessity> : IFileDefinition<TOwnership, TNecessity>, IDllResource
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;

public interface IDllDefinition : IFileDefinition, IDllResource
{
    internal abstract static IDllResource Convert(IDirectoryLocation directory, StorageResourceName name, Action<IDllResourceBuilder>? config = default);
}