using FileCompositions.Core.FileSystem.Addressing.File;
using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.FileSystem.Proxy.File.Source;

namespace FileCompositions.Core.FileSystem.Session.Source;

internal partial interface IFileSystemSessionSource
{
    sealed IFileSystemFileProxySource RequestProxySource(FileSystemFileAddressing addressing) => new FileProxySource(this, addressing);

    private sealed record FileProxySource : IFileSystemFileProxySource
    {
        private readonly IFileSystemSessionSource _source;
        private readonly FileSystemFileAddressing _addressing;

        public FileProxySource(IFileSystemSessionSource source, FileSystemFileAddressing addressing) =>
            (_source, _addressing) = (source, addressing);


        public Task RequestAsync(FileSystemFileProxyRequest request, CancellationToken cancellationToken = default) => _source.RequestAsync((session, ct) =>
        {
            var proxy = session.RequestProxy(_addressing);
            return request(proxy, ct);
        },
            cancellationToken);
        public Task<TResult> RequestAsync<TResult>(FileSystemFileProxyRequest<TResult> request, CancellationToken cancellationToken = default) => _source.RequestAsync((session, ct) =>
        {
            var proxy = session.RequestProxy(_addressing);
            return request(proxy, ct);
        },
            cancellationToken);
    }
}
