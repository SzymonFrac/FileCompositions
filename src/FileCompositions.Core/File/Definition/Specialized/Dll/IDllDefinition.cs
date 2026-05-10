using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Interface.Specialized.Dll;
using FileCompositions.Core.File.Interface.Specialized.Dll.Builder;
using FileCompositions.Core.File.Resource.Specialized.Dll;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Specialized.Dll;

public interface IDllDefinition<TOwnership, TPlacement> : IFileDefinition<TOwnership, TPlacement>, IDllInterface<TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement;

internal interface IDllDefinition : IFileDefinition
{
    abstract static IDllResource Convert(IDirectoryLocation directory, StorageResourceName name, Action<IDllResourceBuilder>? config = default);
}