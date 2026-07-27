using FileCompositions.Core.File.Definition.Ext;
using FileCompositions.Core.File.Quality.Ext;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Diagnostics;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Init.Policy.Implementations;

internal sealed partial class DefaultJsonInitPolicy<TOwnership, TPlacement, TData> : IJsonInitPolicy<TOwnership, TPlacement, TData>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public Func<CancellationToken, ValueTask> GetPolicy(IJsonDefinition<TOwnership, TPlacement, TData> init) => init switch
    {
        IJsonDefinition<StrictDefinition, RequiredInRequired, TData> sr => sr.InitJsonAsync,
        IJsonDefinition<ExternalDefinition, RequiredInRequired, TData> er => er.InitJsonAsync,
        IJsonDefinition<StrictDefinition, OptionalInRequired, TData> so => so.InitJsonAsync,
        IJsonDefinition<ExternalDefinition, OptionalInRequired, TData> eo => eo.InitJsonAsync,
        IJsonDefinition<StrictDefinition, OptionalInOptional, TData> soo => soo.InitJsonAsync,
        IJsonDefinition<ExternalDefinition, OptionalInOptional, TData> eoo => eoo.InitJsonAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultJsonInitPolicy
{
    extension<TData>(IJsonDefinition<StrictDefinition, RequiredInRequired, TData> json)
    {
        public async ValueTask InitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.Context.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false))
            {
                await using var stream = await json.Context.StorageBackend.OpenWriteAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync(stream, json.Default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, RequiredInRequired, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonDefinition<StrictDefinition, OptionalInRequired, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, OptionalInRequired, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonDefinition<StrictDefinition, OptionalInOptional, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, OptionalInOptional, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }
}
