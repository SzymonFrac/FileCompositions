using FileCompositions.Core.FileSystem.Addressing;
using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.FileSystem.Proxy.File.Source;

namespace FileCompositions.Core.FileSystem.Session.Source;

internal partial interface ISessionSource
{
    sealed IFileProxySource RequestProxySource(FileAddressing addressing) => new FileProxySource(this, addressing);

    private sealed record FileProxySource : IFileProxySource
    {
        private readonly ISessionSource _source;
        private readonly FileAddressing _addressing;

        public FileProxySource(ISessionSource source, FileAddressing addressing) =>
            (_source, _addressing) = (source, addressing);


        public Task RequestAsync(FileProxyRequest request, CancellationToken cancellationToken = default) => _source.RequestAsync((session, ct) =>
        {
            var proxy = session.RequestProxy(_addressing);
            return request(proxy, ct);
        },
            cancellationToken);
        public Task<TResult> RequestAsync<TResult>(FileProxyRequest<TResult> request, CancellationToken cancellationToken = default) => _source.RequestAsync((session, ct) =>
        {
            var proxy = session.RequestProxy(_addressing);
            return request(proxy, ct);
        },
            cancellationToken);
    }
}
