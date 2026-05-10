using FileCompositions.Core.File.Resource.Specialized.Json;

namespace FileCompositions.Core.File.Interface.Specialized.Json.Query;

public interface IJsonResourceQuery<TData> : IAsyncEnumerable<IJsonResource<TData>>;
