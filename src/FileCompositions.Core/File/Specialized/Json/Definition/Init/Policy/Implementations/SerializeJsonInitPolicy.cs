using FileCompositions.Core.File.Quality.Ext;
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
    public Func<CancellationToken, ValueTask> GetPolicy(IJsonDefinition<TOwnership, TPlacement, TData> init) => init switch
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
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await using var read = await json.Context.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);

                return;
            }
            catch
            {
                await using var write = await json.Context.StorageBackend.OpenWriteAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync(write, json.Default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, RequiredInRequired, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            await using var read = await json.Context.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
            await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
    }

    extension<TData>(IJsonDefinition<StrictDefinition, OptionalInRequired, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.Context.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken))
                return;

            try
            {
                await using var read = await json.Context.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);

                return;
            }
            catch
            {
                await using var write = await json.Context.StorageBackend.OpenWriteAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync(write, json.Default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, OptionalInRequired, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.Context.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken))
            {
                await using var read = await json.Context.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonDefinition<StrictDefinition, OptionalInOptional, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.Context.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken))
                return;

            try
            {
                await using var read = await json.Context.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);

                return;
            }
            catch
            {
                await using var write = await json.Context.StorageBackend.OpenWriteAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync(write, json.Default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, OptionalInOptional, TData> json)
    {
        public async ValueTask SerializeInitJsonAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.Context.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken))
            {
                await using var read = await json.Context.StorageBackend.OpenReadAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.DeserializeAsync<TData>(read, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}