using FileCompositions.Core.FileSystem.Abstractions.Addressing;
using FileCompositions.Core.FileSystem.Abstractions.Proxy.Request;
using FileCompositions.Core.FileSystem.Abstractions.Proxy.Source;

namespace FileCompositions.Core.FileSystem.Abstractions.Session.Source;

public partial interface IFileSystemSessionSource
{
    sealed IFileSystemProxySource<Entry.Directory> RequestProxySource(/*ref*/ Address address) => new ProxySource<Entry.Directory>(this, new(address));
    sealed IFileSystemProxySource<Entry.File> RequestProxySource(Location location) => new ProxySource<Entry.File>(this, new(location));

    private sealed record ProxySource<TEntry> : IFileSystemProxySource<TEntry>
        where TEntry : Entry
    {
        private readonly IFileSystemSessionSource _source;
        private readonly TEntry _entry;

        public ProxySource(IFileSystemSessionSource source, TEntry entry) => (_source, _entry) = (source, entry);


        public Task RequestAsync(FileSystemProxyRequest<TEntry> request, CancellationToken cancellationToken = default) => _source.RequestAsync((session, ct) =>
        {
            var proxy = session.RequestProxy(_entry);
            return request(proxy, ct);
        },
            cancellationToken);

        public Task<TResult> RequestAsync<TResult>(FileSystemProxyRequest<TEntry, TResult> request, CancellationToken cancellationToken = default) => _source.RequestAsync((session, ct) =>
        {
            var proxy = session.RequestProxy(_entry);
            return request(proxy, ct);
        },
            cancellationToken);
    }
}
