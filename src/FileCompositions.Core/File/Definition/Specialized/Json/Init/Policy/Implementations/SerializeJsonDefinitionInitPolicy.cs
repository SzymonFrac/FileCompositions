using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Diagnostics;
using System.Text.Json;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Init.Policy.Implementations;

internal sealed partial class SerializeJsonDefinitionInitPolicy<TOwnership, TPlacement, TData> : IJsonDefinitionInitPolicy<TOwnership, TPlacement, TData>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public Func<CancellationToken, ValueTask> GetPolicy(IJsonDefinitionInit<TOwnership, TPlacement, TData> init) => init switch
    {
        IJsonDefinitionInit<StrictDefinition, RequiredInRequired, TData> sr => sr.SerializeInitJsonAsync,
        IJsonDefinitionInit<ExternalDefinition, RequiredInRequired, TData> er => er.SerializeInitJsonAsync,
        IJsonDefinitionInit<StrictDefinition, OptionalInRequired, TData> so => so.SerializeInitJsonAsync,
        IJsonDefinitionInit<ExternalDefinition, OptionalInRequired, TData> eo => eo.SerializeInitJsonAsync,
        IJsonDefinitionInit<StrictDefinition, OptionalInOptional, TData> soo => soo.SerializeInitJsonAsync,
        IJsonDefinitionInit<ExternalDefinition, OptionalInOptional, TData> eoo => eoo.SerializeInitJsonAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class SerializeJsonDefinitionInitPolicy
{
    extension<TData>(IJsonDefinitionInit<StrictDefinition, RequiredInRequired, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await using var read = await json.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, cancellationToken: cancellationToken).ConfigureAwait(false);

                return;
            }
            catch
            {
                await using var write = await json.StorageBackend.OpenWriteAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync(write, json.Default, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonDefinitionInit<ExternalDefinition, RequiredInRequired, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            await using var read = await json.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
            await JsonSerializer.DeserializeAsync<TData>(read, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }

    extension<TData>(IJsonDefinitionInit<StrictDefinition, OptionalInRequired, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken))
                return;

            try
            {
                await using var read = await json.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, cancellationToken: cancellationToken).ConfigureAwait(false);

                return;
            }
            catch
            {
                await using var write = await json.StorageBackend.OpenWriteAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync(write, json.Default, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonDefinitionInit<ExternalDefinition, OptionalInRequired, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken))
                return;

            await using var read = await json.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
            await JsonSerializer.DeserializeAsync<TData>(read, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }

    extension<TData>(IJsonDefinitionInit<StrictDefinition, OptionalInOptional, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken))
                return;

            try
            {
                await using var read = await json.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, cancellationToken: cancellationToken).ConfigureAwait(false);

                return;
            }
            catch
            {
                await using var write = await json.StorageBackend.OpenWriteAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync(write, json.Default, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonDefinitionInit<ExternalDefinition, OptionalInOptional, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken))
                return;

            await using var read = await json.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
            await JsonSerializer.DeserializeAsync<TData>(read, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}