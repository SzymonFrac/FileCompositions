using FileCompositions.Core.File.Definition.Init;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Diagnostics;
using System.Text.Json;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Init.Policy.Implementations;

internal sealed partial class DefaultJsonDefinitionInitPolicy<TOwnership, TPlacement, TData> : IJsonDefinitionInitPolicy<TOwnership, TPlacement, TData>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public Func<CancellationToken, ValueTask> GetPolicy(IJsonDefinitionInit<TOwnership, TPlacement, TData> init) => init switch
    {
        IJsonDefinitionInit<StrictDefinition, RequiredInRequired, TData> sr => sr.InitJsonAsync,
        IJsonDefinitionInit<ExternalDefinition, RequiredInRequired, TData> er => er.InitJsonAsync,
        IJsonDefinitionInit<StrictDefinition, OptionalInRequired, TData> so => so.InitJsonAsync,
        IJsonDefinitionInit<ExternalDefinition, OptionalInRequired, TData> eo => eo.InitJsonAsync,
        IJsonDefinitionInit<StrictDefinition, OptionalInOptional, TData> soo => soo.InitJsonAsync,
        IJsonDefinitionInit<ExternalDefinition, OptionalInOptional, TData> eoo => eoo.InitJsonAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultJsonDefinitionInitPolicy
{
    extension<TData>(IJsonDefinitionInit<StrictDefinition, RequiredInRequired, TData> json)
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

    extension<TData>(IJsonDefinitionInit<ExternalDefinition, RequiredInRequired, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonDefinitionInit<StrictDefinition, OptionalInRequired, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonDefinitionInit<ExternalDefinition, OptionalInRequired, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonDefinitionInit<StrictDefinition, OptionalInOptional, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }

    extension<TData>(IJsonDefinitionInit<ExternalDefinition, OptionalInOptional, TData> json)
    {
        public ValueTask InitJsonAsync(CancellationToken cancellationToken = default) =>
            json.InitAsync(cancellationToken);
    }
}
