using FileCompositions.Core.FileSystem.Addressing.Directory;
using FileCompositions.Core.FileSystem.Proxy.Directory;
using FileCompositions.Core.FileSystem.Proxy.Directory.Request;
using FileCompositions.Core.FileSystem.Proxy.Directory.Source;
using FileCompositions.Core.FileSystem.Source;

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


        public Task RequestAsync(FileSystemDirectoryProxyRequest request, CancellationToken cancellationToken = default)
        {
            using var session = _source.RequestSession();
            var proxy = session.RequestProxy(_addressing);

            return request(proxy, cancellationToken);
        }

        public Task<TResult> RequestAsync<TResult>(FileSystemDirectoryProxyRequest<TResult> request, CancellationToken cancellationToken = default)
        {
            using var session = _source.RequestSession();
            var proxy = session.RequestProxy(_addressing);

            return request(proxy, cancellationToken);
        }
    }


    protected readonly ref partial struct Session
    {
        public readonly IFileSystemDirectoryProxy RequestProxy(FileSystemDirectoryAddressing addressing) => new DirectoryProxy(_source, addressing);

        private sealed record DirectoryProxy : IFileSystemDirectoryProxy
        {
            private readonly IFileSystemSource _source;
            private readonly FileSystemDirectoryAddressing _directoryAddressing;

            public DirectoryProxy(IFileSystemSource source, FileSystemDirectoryAddressing directoryAddressing) =>
                (_source, _directoryAddressing) = (source, directoryAddressing);


            public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
                _source.RequestAsync((in fs, ct) => fs.ExistsAsync(_directoryAddressing.Address, ct), cancellationToken);
            public Task CreateAsync(CancellationToken cancellationToken = default) =>
                _source.RequestAsync((in fs, ct) => fs.CreateAsync(_directoryAddressing.Address, ct), cancellationToken);
            public Task DeleteAsync(CancellationToken cancellationToken = default) =>
                _source.RequestAsync((in fs, ct) => fs.DeleteAsync(_directoryAddressing.Address, ct), cancellationToken);
        }
    }
}
