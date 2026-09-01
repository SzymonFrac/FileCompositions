using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Diagnostics;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Init.Policy.Implementations;

internal sealed partial class SerializeJsonInitPolicy<TOwnership, TPlacement, TData> : IJsonInitPolicy<TOwnership, TPlacement, TData>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public Func<CancellationToken, Task> GetPolicy(IJsonDefinition<TOwnership, TPlacement, TData> init) => init switch
    {
        IJsonDefinition<StrictDefinition, RequiredInRequired, TData> sr => sr.SerializeInitJsonAsync,
        IJsonDefinition<ExternalDefinition, RequiredInRequired, TData> er => er.SerializeInitJsonAsync,
        IJsonDefinition<StrictDefinition, OptionalInRequired, TData> so => so.SerializeInitJsonAsync,
        IJsonDefinition<ExternalDefinition, OptionalInRequired, TData> eo => eo.SerializeInitJsonAsync,
        IJsonDefinition<StrictDefinition, OptionalInOptional, TData> soo => soo.SerializeInitJsonAsync,
        IJsonDefinition<ExternalDefinition, OptionalInOptional, TData> eoo => eoo.SerializeInitJsonAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class SerializeJsonInitPolicy
{
    extension<TData>(IJsonDefinition<StrictDefinition, RequiredInRequired, TData> json)
    {
        public Task SerializeInitJsonAsync(CancellationToken cancellationToken = default) =>
            json.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                try
                {
                    await using var read = await proxy.OpenReadAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, ct).ConfigureAwait(false);

                    return;
                }
                catch
                {
                    await using var write = await proxy.OpenWriteAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.SerializeAsync(write, json.Default, json.Format.JsonSerializerOptions, ct).ConfigureAwait(false);
                }
            }),
                cancellationToken);
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, RequiredInRequired, TData> proxy)
    {
        public Task SerializeInitJsonAsync(CancellationToken cancellationToken = default) =>
            proxy.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (fss, ct) =>
            {
                await using var read = await fss.OpenReadAsync(ct).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, proxy.Format.JsonSerializerOptions, ct).ConfigureAwait(false);
            }),
                cancellationToken);
    }

    extension<TData>(IJsonDefinition<StrictDefinition, OptionalInRequired, TData> json)
    {
        public Task SerializeInitJsonAsync(CancellationToken cancellationToken = default) =>
            json.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (!await proxy.ExistsAsync(ct))
                    return;

                try
                {
                    await using var read = await proxy.OpenReadAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, ct).ConfigureAwait(false);

                    return;
                }
                catch
                {
                    await using var write = await proxy.OpenWriteAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.SerializeAsync(write, json.Default, json.Format.JsonSerializerOptions, ct).ConfigureAwait(false);
                }
            }),
                cancellationToken);
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, OptionalInRequired, TData> json)
    {
        public Task SerializeInitJsonAsync(CancellationToken cancellationToken = default) =>
            json.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (!await proxy.ExistsAsync(ct))
                {
                    await using var read = await proxy.OpenReadAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, ct).ConfigureAwait(false);
                }
            }),
                cancellationToken);
    }

    extension<TData>(IJsonDefinition<StrictDefinition, OptionalInOptional, TData> json)
    {
        public Task SerializeInitJsonAsync(CancellationToken cancellationToken = default) =>
            json.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (!await proxy.ExistsAsync(ct))
                    return;

                try
                {
                    await using var read = await proxy.OpenReadAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, ct).ConfigureAwait(false);

                    return;
                }
                catch
                {
                    await using var write = await proxy.OpenWriteAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.SerializeAsync(write, json.Default, json.Format.JsonSerializerOptions, ct).ConfigureAwait(false);
                }
            }),
                cancellationToken);
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, OptionalInOptional, TData> json)
    {
        public Task SerializeInitJsonAsync(CancellationToken cancellationToken = default) =>
            json.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (!await proxy.ExistsAsync(ct))
                {
                    await using var read = await proxy.OpenReadAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, ct).ConfigureAwait(false);
                }
            }),
                cancellationToken);
    }
}