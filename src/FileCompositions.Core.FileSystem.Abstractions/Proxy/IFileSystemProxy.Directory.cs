using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.FileSystem.Abstractions.Proxy;

public static partial class FileSystemProxy
{
    extension(IFileSystemProxy<Entry.Directory> proxy)
    {
        private Address Address => proxy.Entry.Addressing.Address;

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            proxy.Session.Source.RequestAsync((in fs, ct) => fs.ExistsAsync(proxy.Address, ct), cancellationToken);
        public Task CreateAsync(CancellationToken cancellationToken = default) =>
            proxy.Session.Source.RequestAsync((in fs, ct) => fs.CreateAsync(proxy.Address, ct), cancellationToken);
        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            proxy.Session.Source.RequestAsync((in fs, ct) => fs.DeleteAsync(proxy.Address, ct), cancellationToken);
    }
}
