using FileCompositions.Core.FileSystem.Addressing.Directory;
using FileCompositions.Core.FileSystem.Proxy.Directory;

namespace FileCompositions.Core.FileSystem.Session;

internal partial interface IFileSystemSession
{
    sealed IFileSystemDirectoryProxy RequestProxy(in FileSystemDirectoryAddressing addressing) =>
        new DirectoryProxy(this, in addressing);

    private sealed record DirectoryProxy : IFileSystemDirectoryProxy
    {
        private readonly IFileSystemSession _session;
        private readonly FileSystemDirectoryAddressing _directoryAddressing;

        public DirectoryProxy(in IFileSystemSession session, in FileSystemDirectoryAddressing directoryAddressing) =>
            (_session, _directoryAddressing) = (session, directoryAddressing);


        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.ExistsAsync(_directoryAddressing.Address, ct), cancellationToken);
        public Task CreateAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.CreateAsync(_directoryAddressing.Address, ct), cancellationToken);
        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.DeleteAsync(_directoryAddressing.Address, ct), cancellationToken);
    }
}
