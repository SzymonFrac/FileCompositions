using FileCompositions.Core.File.Resource.Specialized.Json.Context;
using FileCompositions.Core.File.Resource.Specialized.Json.Interface;

namespace FileCompositions.Core.File.Resource.Specialized.Json;

public interface IJsonResource<TData> : IFileResource, IJsonResourceInterface<TData>
{
    internal new IJsonResourceContext Context { get; }
}
