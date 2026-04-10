using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Json;

public interface IJsonDefinition<TData> : IFileDefinition, IJsonFileResource<TData>
{
    internal abstract static IJsonFileResource<TData> Convert(IDirectoryLocation directory, StorageResourceName name, Action<IJsonFileResourceBuilder<TData>>? config = default);
}