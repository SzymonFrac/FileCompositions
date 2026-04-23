namespace FileCompositions.Core.File.Resource.Specialized.Json.Query;

public interface IJsonResourceQuery<TData> : IAsyncEnumerable<IJsonResource<TData>>;
