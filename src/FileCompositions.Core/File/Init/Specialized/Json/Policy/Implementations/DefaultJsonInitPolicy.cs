using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Diagnostics;
using System.Text.Json;

namespace FileCompositions.Core.File.Init.Specialized.Json.Policy.Implementations;

internal sealed partial class DefaultJsonInitPolicy<TOwnership, TPlacement, TData> : IJsonInitPolicy<TOwnership, TPlacement, TData>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public Func<CancellationToken, ValueTask> GetPolicy(IJsonInit<TOwnership, TPlacement, TData> init) => init switch
    {
        IJsonInit<StrictDefinition, RequiredInRequired, TData> sr => sr.InitJsonAsync,
        IJsonInit<ExternalDefinition, RequiredInRequired, TData> er => er.InitJsonAsync,
        IJsonInit<StrictDefinition, OptionalInRequired, TData> so => so.InitJsonAsync,
        IJsonInit<ExternalDefinition, OptionalInRequired, TData> eo => eo.InitJsonAsync,
        IJsonInit<StrictDefinition, OptionalInOptional, TData> soo => soo.InitJsonAsync,
        IJsonInit<ExternalDefinition, OptionalInOptional, TData> eoo => eoo.InitJsonAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultJsonInitPolicy
{
    extension<TData>(IJsonInit<StrictDefinition, RequiredInRequired, TData> json)
    {
        public async ValueTask InitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false))
            {
                await using var stream = await json.StorageBackend.OpenWriteAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync(stream, json.Default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonInit<ExternalDefinition, RequiredInRequired, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonInit<StrictDefinition, OptionalInRequired, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonInit<ExternalDefinition, OptionalInRequired, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonInit<StrictDefinition, OptionalInOptional, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonInit<ExternalDefinition, OptionalInOptional, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }
}
