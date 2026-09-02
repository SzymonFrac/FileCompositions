using FileCompositions.Core.FileSystem.Addressing.File;
using FileCompositions.Core.FileSystem.Proxy.File;
using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.FileSystem.Proxy.File.Source;
using FileCompositions.Core.FileSystem.Source;

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


        public Task RequestAsync(FileSystemFileProxyRequest request, CancellationToken cancellationToken = default)
        {
            using var session = _source.RequestSession();
            var proxy = session.RequestProxy(_addressing);

            return request(proxy, cancellationToken);
        }
        public Task<TResult> RequestAsync<TResult>(FileSystemFileProxyRequest<TResult> request, CancellationToken cancellationToken = default)
        {
            using var session = _source.RequestSession();
            var proxy = session.RequestProxy(_addressing);

            return request(proxy, cancellationToken);
        }
    }


    protected readonly ref partial struct Session
    {
        public readonly IFileSystemFileProxy RequestProxy(FileSystemFileAddressing addressing) => new FileProxy(_source, addressing);

        private sealed record FileProxy : IFileSystemFileProxy
        {
            private readonly IFileSystemSource _source;
            private readonly FileSystemFileAddressing _fileAddressing;

            public FileProxy(IFileSystemSource source, FileSystemFileAddressing fileAddressing) =>
                (_source, _fileAddressing) = (source, fileAddressing);


            public Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
                _source.RequestAsync((in fs, ct) => fs.OpenReadAsync(_fileAddressing.Location, ct), cancellationToken);
            public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
                _source.RequestAsync((in fs, ct) => fs.OpenWriteAsync(_fileAddressing.Location, ct), cancellationToken);
            public Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
                _source.RequestAsync((in fs, ct) => fs.OpenAppendAsync(_fileAddressing.Location, ct), cancellationToken);
            public Task<Stream> OpenCreateAsync(CancellationToken cancellationToken = default) =>
                _source.RequestAsync((in fs, ct) => fs.OpenCreateAsync(_fileAddressing.Location, ct), cancellationToken);

            public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
                _source.RequestAsync((in fs, ct) => fs.ExistsAsync(_fileAddressing.Location, ct), cancellationToken);
            public Task<bool> AddressExistsAsync(CancellationToken cancellationToken = default) =>
                _source.RequestAsync((in fs, ct) => fs.ExistsAsync(_fileAddressing.Address, ct), cancellationToken);
            public Task CreateAsync(CancellationToken cancellationToken = default) =>
                _source.RequestAsync((in fs, ct) => fs.CreateAsync(_fileAddressing.Location, ct), cancellationToken);
            public Task DeleteAsync(CancellationToken cancellationToken = default) =>
                _source.RequestAsync((in fs, ct) => fs.DeleteAsync(_fileAddressing.Location, ct), cancellationToken);
        }
    }
}
