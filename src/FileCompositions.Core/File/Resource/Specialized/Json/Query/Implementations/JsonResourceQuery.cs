namespace FileCompositions.Core.File.Resource.Specialized.Json.Query.Implementations;

internal class JsonResourceQuery<TData>(IAsyncEnumerable<IJsonResource<TData>> source) : IJsonResourceQuery<TData>
{
    private readonly IAsyncEnumerable<IJsonResource<TData>> _source = source;
    public IAsyncEnumerator<IJsonResource<TData>> GetAsyncEnumerator(CancellationToken cancellationToken = default) =>
        _source.GetAsyncEnumerator(cancellationToken);
}
