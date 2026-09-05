using FileCompositions.Core.FileSystem.Addressing.Directory;
using FileCompositions.Core.FileSystem.Proxy.Directory.Request;
using FileCompositions.Core.FileSystem.Proxy.Directory.Source;

namespace FileCompositions.Core.FileSystem.Session.Source;

internal partial interface IFileSystemSessionSource
{
    sealed IFileSystemDirectoryProxySource RequestProxySource(FileSystemDirectoryAddressing addressing) => new DirectoryProxySource(this, addressing);

    private sealed record DirectoryProxySource : IFileSystemDirectoryProxySource
    {
        private readonly IFileSystemSessionSource _source;
        private readonly FileSystemDirectoryAddressing _addressing;

        public DirectoryProxySource(IFileSystemSessionSource source, FileSystemDirectoryAddressing addressing) =>
            (_source, _addressing) = (source, addressing);


        public Task RequestAsync(FileSystemDirectoryProxyRequest request, CancellationToken cancellationToken = default) => _source.RequestAsync((session, ct) =>
        {
            var proxy = session.RequestProxy(_addressing);
            return request(proxy, ct);
        },
            cancellationToken);

        public Task<TResult> RequestAsync<TResult>(FileSystemDirectoryProxyRequest<TResult> request, CancellationToken cancellationToken = default) => _source.RequestAsync((session, ct) =>
        {
            var proxy = session.RequestProxy(_addressing);
            return request(proxy, ct);
        },
            cancellationToken);
    }
}
