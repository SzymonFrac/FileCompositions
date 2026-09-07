using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Quality.Ext;

public static partial class FileQualityExt
{
    extension<TOwnership>(IFileQuality<TOwnership, Placement.RequiredInRequired> file)
        where TOwnership : Ownership
    {
        internal Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.OpenReadAsync(ct), cancellationToken);
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.OpenWriteAsync(ct), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.OpenAppendAsync(ct), cancellationToken);
    }

    extension(IFileQuality<Ownership.Internal, Placement.OptionalInRequired> file)
    {
        internal Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest<Stream?>)(async (proxy, ct) =>
                await proxy.ExistsAsync(ct).ConfigureAwait(false)
                    ? await proxy.OpenReadAsync(ct).ConfigureAwait(false)
                    : default),
                cancellationToken);
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.OpenWriteAsync(ct), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.OpenAppendAsync(ct), cancellationToken);
    }

    extension(IFileQuality<Ownership.External, Placement.OptionalInRequired> file)
    {
        internal Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest<Stream?>)(async (proxy, ct) =>
                await proxy.ExistsAsync(ct).ConfigureAwait(false)
                    ? await proxy.OpenReadAsync(ct).ConfigureAwait(false)
                    : default),
                cancellationToken);
        internal Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest<Stream?>)(async (proxy, ct) =>
                await proxy.ExistsAsync(ct).ConfigureAwait(false)
                    ? await proxy.OpenWriteAsync(ct).ConfigureAwait(false)
                    : default),
                cancellationToken);
        internal Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest<Stream?>)(async (proxy, ct) =>
                await proxy.ExistsAsync(ct).ConfigureAwait(false)
                    ? await proxy.OpenAppendAsync(ct).ConfigureAwait(false)
                    : default),
                cancellationToken);
    }

    extension(IFileQuality<Ownership.Internal, Placement.OptionalInOptional> file)
    {
        internal Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest<Stream?>)(async (proxy, ct) =>
                await proxy.ExistsAsync(ct).ConfigureAwait(false)
                    ? await proxy.OpenReadAsync(ct).ConfigureAwait(false)
                    : default),
                cancellationToken);
        internal Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest<Stream?>)(async (proxy, ct) =>
                await proxy.ExistsAsync(ct).ConfigureAwait(false)
                    ? await proxy.OpenWriteAsync(ct).ConfigureAwait(false)
                    : default),
                cancellationToken);
        internal Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest<Stream?>)(async (proxy, ct) =>
                await proxy.ExistsAsync(ct).ConfigureAwait(false)
                    ? await proxy.OpenAppendAsync(ct).ConfigureAwait(false)
                    : default),
                cancellationToken);
    }

    extension(IFileQuality<Ownership.External, Placement.OptionalInOptional> file)
    {
        internal Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest<Stream?>)(async (proxy, ct) =>
                await proxy.ExistsAsync(ct).ConfigureAwait(false)
                    ? await proxy.OpenReadAsync(ct).ConfigureAwait(false)
                    : default),
                cancellationToken);
        internal Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest<Stream?>)(async (proxy, ct) =>
                await proxy.ExistsAsync(ct).ConfigureAwait(false)
                    ? await proxy.OpenWriteAsync(ct).ConfigureAwait(false)
                    : default),
                cancellationToken);
        internal Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest<Stream?>)(async (proxy, ct) =>
                await proxy.ExistsAsync(ct).ConfigureAwait(false)
                    ? await proxy.OpenAppendAsync(ct).ConfigureAwait(false)
                    : default),
                cancellationToken);
    }
}
