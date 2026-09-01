using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Definition.Ext;

public static partial class FileDefinitionExt
{
    extension<TOwnership>(IFileDefinition<TOwnership, RequiredInRequired> file)
        where TOwnership : DefinitionOwnership
    {

    }

    extension(IFileDefinition<StrictDefinition, OptionalInRequired> file)
    {
        internal Task CreateAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.CreateAsync(ct).AsTask(), cancellationToken);

        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (await proxy.ExistsAsync(ct).ConfigureAwait(false))
                    await proxy.DeleteAsync(ct).ConfigureAwait(false);
            }),
                cancellationToken);

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.ExistsAsync(ct).AsTask(), cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInRequired> file)
    {
        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.ExistsAsync(ct).AsTask(), cancellationToken);
    }

    extension(IFileDefinition<StrictDefinition, OptionalInOptional> file)
    {
        internal Task<bool> TryCreateAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest<bool>)(async (proxy, ct) =>
            {
                var addressExists = await proxy.AddressExistsAsync(ct).ConfigureAwait(false);
                if (addressExists)
                    await proxy.CreateAsync(ct).ConfigureAwait(false);

                return addressExists;
            }),
                cancellationToken);

        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (await proxy.ExistsAsync(ct).ConfigureAwait(false))
                    await proxy.DeleteAsync(ct).ConfigureAwait(false);
            }),
                cancellationToken);

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.ExistsAsync(ct).AsTask(), cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInOptional> file)
    {
        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((proxy, ct) => proxy.ExistsAsync(ct).AsTask(), cancellationToken);
    }
}
