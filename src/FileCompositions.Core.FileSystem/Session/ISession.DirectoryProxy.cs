using FileCompositions.Core.FileSystem.Addressing;
using FileCompositions.Core.FileSystem.Proxy.Directory;

namespace FileCompositions.Core.FileSystem.Session;

internal partial interface ISession
{
    sealed IDirectoryProxy RequestProxy(in DirectoryAddressing addressing) =>
        new DirectoryProxy(this, in addressing);

    private sealed record DirectoryProxy : IDirectoryProxy
    {
        private readonly ISession _session;
        private readonly DirectoryAddressing _directoryAddressing;

        public DirectoryProxy(in ISession session, in DirectoryAddressing directoryAddressing) =>
            (_session, _directoryAddressing) = (session, directoryAddressing);


        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.ExistsAsync(_directoryAddressing.Address, ct), cancellationToken);
        public Task CreateAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.CreateAsync(_directoryAddressing.Address, ct), cancellationToken);
        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            _session.Source.RequestAsync((in fs, ct) => fs.DeleteAsync(_directoryAddressing.Address, ct), cancellationToken);
    }
}
