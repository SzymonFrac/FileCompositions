using FileCompositions.Core.File.Resource.Specialized.Json;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Query;

public interface IJsonFileResourceQuery<TData> : IEnumerable<IJsonFileResource<TData>>
{

}
