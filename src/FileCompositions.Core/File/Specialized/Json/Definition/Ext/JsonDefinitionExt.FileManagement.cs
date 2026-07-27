using FileCompositions.Core.File.Quality.Ext;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Ext;

public static partial class JsonDefinitionExt
{
    extension<TData>(IJsonDefinition<StrictDefinition, RequiredInRequired, TData> json)
    {

    }

    extension<TData>(IJsonDefinition<ExternalDefinition, RequiredInRequired, TData> json)
    {

    }

    extension<TData>(IJsonDefinition<StrictDefinition, OptionalInRequired, TData> json)
    {
        public async ValueTask CreateAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.Context.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false))
            {
                await using var stream = await json.Context.StorageBackend.OpenCreateAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync<TData?>(stream, default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, OptionalInRequired, TData> json)
    {

    }

    extension<TData>(IJsonDefinition<StrictDefinition, OptionalInOptional, TData> json)
    {
        public async ValueTask<bool> TryCreateAsync(CancellationToken cancellationToken = default)
        {
            var addressExists = await json.Context.StorageBackend.ExistsAsync(json.GetLocation().Address, cancellationToken).ConfigureAwait(false);
            if (addressExists)
            {
                await using var stream = await json.Context.StorageBackend.OpenCreateAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync<TData?>(stream, default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }

            return addressExists;
        }
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, OptionalInOptional, TData> json)
    {

    }
}
