using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Diagnostics;
using System.Text.Json;

namespace FileCompositions.Core.File.Init.Specialized.Json.Policy.Implementations;

internal sealed partial class SerializeJsonInitPolicy<TOwnership, TPlacement, TData> : IJsonInitPolicy<TOwnership, TPlacement, TData>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public Func<CancellationToken, ValueTask> GetPolicy(IJsonInit<TOwnership, TPlacement, TData> init) => init switch
    {
        IJsonInit<StrictDefinition, RequiredInRequired, TData> sr => sr.SerializeInitJsonAsync,
        IJsonInit<ExternalDefinition, RequiredInRequired, TData> er => er.SerializeInitJsonAsync,
        IJsonInit<StrictDefinition, OptionalInRequired, TData> so => so.SerializeInitJsonAsync,
        IJsonInit<ExternalDefinition, OptionalInRequired, TData> eo => eo.SerializeInitJsonAsync,
        IJsonInit<StrictDefinition, OptionalInOptional, TData> soo => soo.SerializeInitJsonAsync,
        IJsonInit<ExternalDefinition, OptionalInOptional, TData> eoo => eoo.SerializeInitJsonAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class SerializeJsonInitPolicy
{
    extension<TData>(IJsonInit<StrictDefinition, RequiredInRequired, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await using var read = await json.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);

                return;
            }
            catch
            {
                await using var write = await json.StorageBackend.OpenWriteAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync(write, json.Default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonInit<ExternalDefinition, RequiredInRequired, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            await using var read = await json.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
            await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
    }

    extension<TData>(IJsonInit<StrictDefinition, OptionalInRequired, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken))
                return;

            try
            {
                await using var read = await json.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);

                return;
            }
            catch
            {
                await using var write = await json.StorageBackend.OpenWriteAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync(write, json.Default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonInit<ExternalDefinition, OptionalInRequired, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken))
            {
                await using var read = await json.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonInit<StrictDefinition, OptionalInOptional, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken))
                return;

            try
            {
                await using var read = await json.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);

                return;
            }
            catch
            {
                await using var write = await json.StorageBackend.OpenWriteAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync(write, json.Default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonInit<ExternalDefinition, OptionalInOptional, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken))
            {
                await using var read = await json.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}