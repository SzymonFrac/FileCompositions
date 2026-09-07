using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Ext;

public static partial class JsonDefinitionExt
{
    extension<TData>(IJsonDefinition<Ownership.Internal, Placement.RequiredInRequired, TData> json)
    {

    }

    extension<TData>(IJsonDefinition<Ownership.External, Placement.RequiredInRequired, TData> json)
    {

    }

    extension<TData>(IJsonDefinition<Ownership.Internal, Placement.OptionalInRequired, TData> json)
    {
        public Task CreateAsync(CancellationToken cancellationToken = default) =>
            json.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (await proxy.ExistsAsync(ct).ConfigureAwait(false))
                {
                    await using var stream = await proxy.OpenCreateAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.SerializeAsync<TData?>(stream, default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }),
                cancellationToken);
    }

    extension<TData>(IJsonDefinition<Ownership.External, Placement.OptionalInRequired, TData> json)
    {

    }

    extension<TData>(IJsonDefinition<Ownership.Internal, Placement.OptionalInOptional, TData> json)
    {
        public Task<bool> TryCreateAsync(CancellationToken cancellationToken = default) =>
            json.ProxySource.RequestAsync((FileSystemFileProxyRequest<bool>)(async (proxy, ct) =>
            {
                var addressExists = await proxy.AddressExistsAsync(ct).ConfigureAwait(false);
                if (addressExists)
                {
                    await using var stream = await proxy.OpenCreateAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.SerializeAsync<TData?>(stream, default, json.Format.JsonSerializerOptions, ct).ConfigureAwait(false);
                }

                return addressExists;
            }),
                cancellationToken);
    }

    extension<TData>(IJsonDefinition<Ownership.External, Placement.OptionalInOptional, TData> json)
    {

    }
}
