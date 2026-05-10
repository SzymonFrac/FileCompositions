using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Interface.Specialized.Json;
using FileCompositions.Core.File.Interface.Specialized.Json.Builder;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Specialized.Json;

public interface IJsonDefinition<TOwnership, TPlacement, TData> : IFileDefinition<TOwnership, TPlacement>, IJsonInterface<TPlacement, TData>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement;

internal interface IJsonDefinition : IFileDefinition
{
    abstract static IJsonResource<TData> Convert<TData>(IDirectoryLocation directory, StorageResourceName name, Action<IJsonResourceBuilder<TData>>? config = default);
}
