using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Text.Json;

namespace FileCompositions.Core.File.Operator.Specialized.Json;

public static class JsonOperator
{
    extension<TData>(IJsonOperator<StrictDefinition, RequiredInRequired, TData> json)
    {

    }

    extension<TData>(IJsonOperator<ExternalDefinition, RequiredInRequired, TData> json)
    {

    }

    extension<TData>(IJsonOperator<StrictDefinition, OptionalInRequired, TData> json)
    {
        public async ValueTask CreateAsync(CancellationToken cancellationToken = default)
        {
            if (!await json.StorageBackend.ExistsAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false))
            {
                await using var stream = await json.StorageBackend.OpenCreateAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync<TData?>(stream, default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension<TData>(IJsonOperator<ExternalDefinition, OptionalInRequired, TData> json)
    {

    }

    extension<TData>(IJsonOperator<StrictDefinition, OptionalInOptional, TData> json)
    {
        public async ValueTask<bool> TryCreateAsync(CancellationToken cancellationToken = default)
        {
            var addressExists = await json.StorageBackend.ExistsAsync(json.GetLocation().Address, cancellationToken).ConfigureAwait(false);
            if (addressExists)
            {
                await using var stream = await json.StorageBackend.OpenCreateAsync(json.GetLocation(), cancellationToken).ConfigureAwait(false);
                await JsonSerializer.SerializeAsync<TData?>(stream, default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            }

            return addressExists;
        }
    }

    extension<TData>(IJsonOperator<ExternalDefinition, OptionalInOptional, TData> json)
    {

    }
}
