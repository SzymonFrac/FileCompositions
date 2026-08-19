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
        public Task CreateAsync(CancellationToken cancellationToken = default) =>
            json.RequestFileSystemAsync(async (fss, ct) =>
            {
                if (await fss.ExistsAsync(ct).ConfigureAwait(false))
                {
                    await using var stream = await fss.OpenCreateAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.SerializeAsync<TData?>(stream, default, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
                }
            },
                cancellationToken);
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, OptionalInRequired, TData> json)
    {

    }

    extension<TData>(IJsonDefinition<StrictDefinition, OptionalInOptional, TData> json)
    {
        public Task<bool> TryCreateAsync(CancellationToken cancellationToken = default) =>
            json.RequestFileSystemAsync(async (fss, ct) =>
            {
                var addressExists = await fss.AddressExistsAsync(ct).ConfigureAwait(false);
                if (addressExists)
                {
                    await using var stream = await fss.OpenCreateAsync(ct).ConfigureAwait(false);
                    await JsonSerializer.SerializeAsync<TData?>(stream, default, json.Format.JsonSerializerOptions, ct).ConfigureAwait(false);
                }

                return addressExists;
            },
                cancellationToken);
    }

    extension<TData>(IJsonDefinition<ExternalDefinition, OptionalInOptional, TData> json)
    {

    }
}
