using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.File.Resource.Specialized.Json.Query;
using System.Collections;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Query.Implementations;

internal class JsonFileResourceQuery<TData>(IEnumerable<IJsonFileResource<TData>> source) : IJsonFileResourceQuery<TData>
{
    private readonly IEnumerable<IJsonFileResource<TData>> _source = source;
    public IEnumerator<IJsonFileResource<TData>> GetEnumerator() => _source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _source.GetEnumerator();
}
