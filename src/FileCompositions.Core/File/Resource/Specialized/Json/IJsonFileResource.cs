using FileCompositions.Core.File.Resource.Specialized.Json.Context;
using FileCompositions.Core.File.Resource.Specialized.Json.FileInterface;

namespace FileCompositions.Core.File.Resource.Specialized.Json;

public interface IJsonFileResource<TData> : ISpecializedFileResource, IJsonFileResourceFileInterface<TData>
{
    internal new IJsonFileResourceContext Context { get; }
}
