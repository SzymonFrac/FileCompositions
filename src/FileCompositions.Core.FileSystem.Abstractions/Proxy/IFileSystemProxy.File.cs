using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.FileSystem.Abstractions.Proxy;

public static partial class FileSystemProxy
{
    extension(IFileSystemProxy<Entry.File> proxy)
    {
        private Address Address => proxy.Entry.Addressing.Address;
        private Location Location => proxy.Entry.Addressing.Location;

        public Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
            proxy.Session.Source.RequestAsync((in fs, ct) => fs.OpenReadAsync(proxy.Location, ct), cancellationToken);
        public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            proxy.Session.Source.RequestAsync((in fs, ct) => fs.OpenWriteAsync(proxy.Location, ct), cancellationToken);
        public Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            proxy.Session.Source.RequestAsync((in fs, ct) => fs.OpenAppendAsync(proxy.Location, ct), cancellationToken);
        public Task<Stream> OpenCreateAsync(CancellationToken cancellationToken = default) =>
            proxy.Session.Source.RequestAsync((in fs, ct) => fs.OpenCreateAsync(proxy.Location, ct), cancellationToken);

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            proxy.Session.Source.RequestAsync((in fs, ct) => fs.ExistsAsync(proxy.Location, ct), cancellationToken);
        public Task<bool> AddressExistsAsync(CancellationToken cancellationToken = default) =>
            proxy.Session.Source.RequestAsync((in fs, ct) => fs.ExistsAsync(proxy.Address, ct), cancellationToken);
        public Task CreateAsync(CancellationToken cancellationToken = default) =>
            proxy.Session.Source.RequestAsync((in fs, ct) => fs.CreateAsync(proxy.Location, ct), cancellationToken);
        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            proxy.Session.Source.RequestAsync((in fs, ct) => fs.DeleteAsync(proxy.Location, ct), cancellationToken);
    }
}
