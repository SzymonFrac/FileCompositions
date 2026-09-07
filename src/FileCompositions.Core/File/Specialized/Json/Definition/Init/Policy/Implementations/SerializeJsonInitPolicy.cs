using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality;
using System.Diagnostics;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Init.Policy.Implementations;

internal sealed partial class SerializeJsonInitPolicy<TOwnership, TPlacement, TData> : IJsonInitPolicy<TOwnership, TPlacement, TData>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    public Func<CancellationToken, Task> GetPolicy(IJsonDefinition<TOwnership, TPlacement, TData> init) => init switch
    {
        IJsonDefinition<Ownership.Internal, Placement.RequiredInRequired, TData> sr => sr.SerializeInitJsonAsync,
        IJsonDefinition<Ownership.External, Placement.RequiredInRequired, TData> er => er.SerializeInitJsonAsync,
        IJsonDefinition<Ownership.Internal, Placement.OptionalInRequired, TData> so => so.SerializeInitJsonAsync,
        IJsonDefinition<Ownership.External, Placement.OptionalInRequired, TData> eo => eo.SerializeInitJsonAsync,
        IJsonDefinition<Ownership.Internal, Placement.OptionalInOptional, TData> soo => soo.SerializeInitJsonAsync,
        IJsonDefinition<Ownership.External, Placement.OptionalInOptional, TData> eoo => eoo.SerializeInitJsonAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class SerializeJsonInitPolicy
{
    extension<TData>(IJsonDefinition<Ownership.Internal, Placement.RequiredInRequired, TData> json)
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

    extension<TData>(IJsonDefinition<Ownership.External, Placement.RequiredInRequired, TData> proxy)
    {
        public Task SerializeInitJsonAsync(CancellationToken cancellationToken = default) =>
            proxy.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (fss, ct) =>
            {
                await using var read = await fss.OpenReadAsync(ct).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, proxy.Format.JsonSerializerOptions, ct).ConfigureAwait(false);
            }),
                cancellationToken);
    }

    extension<TData>(IJsonDefinition<Ownership.Internal, Placement.OptionalInRequired, TData> json)
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

    extension<TData>(IJsonDefinition<Ownership.External, Placement.OptionalInRequired, TData> json)
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

    extension<TData>(IJsonDefinition<Ownership.Internal, Placement.OptionalInOptional, TData> json)
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

    extension<TData>(IJsonDefinition<Ownership.External, Placement.OptionalInOptional, TData> json)
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