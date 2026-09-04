using FileCompositions.Core.FileSystem.Addressing.File;
using FileCompositions.Core.FileSystem.Proxy.File;

namespace FileCompositions.Core.FileSystem.Session;

internal partial interface IFileSystemSession
{
    sealed IFileSystemFileProxy RequestProxy(in FileSystemFileAddressing addressing) =>
        new FileProxy(this, in addressing);

    private sealed record FileProxy : IFileSystemFileProxy
    {
        private readonly IFileSystemSession _session;
        private readonly FileSystemFileAddressing _fileAddressing;

        public FileProxy(in IFileSystemSession session, in FileSystemFileAddressing fileAddressing) =>
            (_session, _fileAddressing) = (session, fileAddressing);


        public Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.OpenReadAsync(_fileAddressing.Location, ct), cancellationToken);
        public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.OpenWriteAsync(_fileAddressing.Location, ct), cancellationToken);
        public Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.OpenAppendAsync(_fileAddressing.Location, ct), cancellationToken);
        public Task<Stream> OpenCreateAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.OpenCreateAsync(_fileAddressing.Location, ct), cancellationToken);

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.ExistsAsync(_fileAddressing.Location, ct), cancellationToken);
        public Task<bool> AddressExistsAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.ExistsAsync(_fileAddressing.Address, ct), cancellationToken);
        public Task CreateAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.CreateAsync(_fileAddressing.Location, ct), cancellationToken);
        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.DeleteAsync(_fileAddressing.Location, ct), cancellationToken);
    }
}
