using FileCompositions.Core.FileSystem.Addressing;
using FileCompositions.Core.FileSystem.Proxy.Directory.Request;
using FileCompositions.Core.FileSystem.Proxy.Directory.Source;

namespace FileCompositions.Core.FileSystem.Session.Source;

internal partial interface ISessionSource
{
    sealed IDirectoryProxySource RequestProxySource(DirectoryAddressing addressing) => new DirectoryProxySource(this, addressing);

    private sealed record DirectoryProxySource : IDirectoryProxySource
    {
        private readonly ISessionSource _source;
        private readonly DirectoryAddressing _addressing;

        public DirectoryProxySource(ISessionSource source, DirectoryAddressing addressing) =>
            (_source, _addressing) = (source, addressing);


        public Task RequestAsync(DirectoryProxyRequest request, CancellationToken cancellationToken = default) => _source.RequestAsync((session, ct) =>
        {
            var proxy = session.RequestProxy(_addressing);
            return request(proxy, ct);
        },
            cancellationToken);

        public Task<TResult> RequestAsync<TResult>(DirectoryProxyRequest<TResult> request, CancellationToken cancellationToken = default) => _source.RequestAsync((session, ct) =>
        {
            var proxy = session.RequestProxy(_addressing);
            return request(proxy, ct);
        },
            cancellationToken);
    }
}
