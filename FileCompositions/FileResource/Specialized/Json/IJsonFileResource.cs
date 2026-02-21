using FileCompositions.Core.FileResource.Specialized.Json.Context;
using FileCompositions.Core.FileResource.Specialized.Json.FileInterface;

namespace FileCompositions.Core.FileResource.Specialized.Json;

public interface IJsonFileResource<TData> : ISpecializedFileResource, IJsonFileResourceFileInterface<TData>
{
    internal new IJsonFileResourceContext Context { get; }
}
