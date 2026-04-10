using FileCompositions.Core.File.Resource.Specialized;
using FileCompositions.Core.File.Resource.Specialized.Query;

namespace FileCompositions.Core.File.Resource.Specialized.Query.Implementations;

internal class SpecializedFileResourceQuery(IAsyncEnumerable<ISpecializedFileResource?> source) : ISpecializedFileResourceQuery
{
    private readonly IAsyncEnumerable<ISpecializedFileResource?> _source = source;
    public IAsyncEnumerator<ISpecializedFileResource?> GetAsyncEnumerator(CancellationToken cancellationToken = default) =>
        _source.GetAsyncEnumerator(cancellationToken);
}