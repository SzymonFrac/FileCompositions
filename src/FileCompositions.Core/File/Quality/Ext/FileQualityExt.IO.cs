using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Quality.Ext;

public static partial class FileQualityExt
{
    extension<TOwnership>(IFileQuality<TOwnership, RequiredInRequired> file)
        where TOwnership : DefinitionOwnership
    {
        internal Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.OpenReadAsync(ct), cancellationToken);
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.OpenWriteAsync(ct), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.OpenAppendAsync(ct), cancellationToken);
    }

    extension(IFileQuality<StrictDefinition, OptionalInRequired> file)
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

    extension(IFileQuality<ExternalDefinition, OptionalInRequired> file)
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

    extension(IFileQuality<StrictDefinition, OptionalInOptional> file)
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

    extension(IFileQuality<ExternalDefinition, OptionalInOptional> file)
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
