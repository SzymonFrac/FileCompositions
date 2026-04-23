using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Specialized.Json;

public interface IJsonDefinition<TOwnership, TNecessity, TData> : IFileDefinition<TOwnership, TNecessity>, IJsonResource<TData>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;

public interface IJsonDefinition<TData> : IFileDefinition, IJsonResource<TData>
{
    internal abstract static IJsonResource<TData> Convert(IDirectoryLocation directory, StorageResourceName name, Action<IJsonResourceBuilder<TData>>? config = default);
}
