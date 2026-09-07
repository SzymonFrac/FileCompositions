using FileCompositions.Core.File.Definition.Ext;
using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality;
using System.Diagnostics;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Init.Policy.Implementations;

internal sealed partial class DefaultJsonInitPolicy<TOwnership, TPlacement, TData> : IJsonInitPolicy<TOwnership, TPlacement, TData>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    public Func<CancellationToken, Task> GetPolicy(IJsonDefinition<TOwnership, TPlacement, TData> init) => init switch
    {
        IJsonDefinition<Ownership.Internal, Placement.RequiredInRequired, TData> sr => sr.InitJsonAsync,
        IJsonDefinition<Ownership.External, Placement.RequiredInRequired, TData> er => er.InitJsonAsync,
        IJsonDefinition<Ownership.Internal, Placement.OptionalInRequired, TData> so => so.InitJsonAsync,
        IJsonDefinition<Ownership.External, Placement.OptionalInRequired, TData> eo => eo.InitJsonAsync,
        IJsonDefinition<Ownership.Internal, Placement.OptionalInOptional, TData> soo => soo.InitJsonAsync,
        IJsonDefinition<Ownership.External, Placement.OptionalInOptional, TData> eoo => eoo.InitJsonAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultJsonInitPolicy
{
    extension<TData>(IJsonDefinition<Ownership.Internal, Placement.RequiredInRequired, TData> json)
    {
        public Task InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (!await proxy.ExistsAsync(ct).ConfigureAwait(false))
                {
                    await using var stream = await proxy.OpenWriteAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.SerializeAsync(stream, json.Default, json.Format.JsonSerializerOptions, ct).ConfigureAwait(false);
                }
            }),
                cancellationToken);
    }

    extension<TData>(IJsonDefinition<Ownership.External, Placement.RequiredInRequired, TData> json)
    {
        public Task InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonDefinition<Ownership.Internal, Placement.OptionalInRequired, TData> json)
    {
        public Task InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonDefinition<Ownership.External, Placement.OptionalInRequired, TData> json)
    {
        public Task InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonDefinition<Ownership.Internal, Placement.OptionalInOptional, TData> json)
    {
        public Task InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonDefinition<Ownership.External, Placement.OptionalInOptional, TData> json)
    {
        public Task InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }
}
