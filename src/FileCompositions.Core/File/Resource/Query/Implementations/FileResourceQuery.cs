namespace FileCompositions.Core.File.Resource.Query.Implementations;

internal class FileResourceQuery(IAsyncEnumerable<IFileResource?> source) : IFileResourceQuery
{
    private readonly IAsyncEnumerable<IFileResource?> _source = source;
    public IAsyncEnumerator<IFileResource?> GetAsyncEnumerator(CancellationToken cancellationToken = default) =>
        _source.GetAsyncEnumerator(cancellationToken);
}