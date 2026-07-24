using FileCompositions.Core.File.Quality.Ext;
using FileCompositions.Core.File.Specialized.Json.ReadResult;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Ext;

public static partial class JsonQualityExt
{
    extension<TOwnership, TData>(IJsonQuality<TOwnership, RequiredInRequired, TData> json)
        where TOwnership : DefinitionOwnership
    {
        public async Task<TData?> ReadAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
        public async Task WriteAsync(TData value, CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenWriteAsync(cancellationToken).ConfigureAwait(false);
            await JsonSerializer.SerializeAsync(stream, value, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
    }

    extension<TData>(IJsonQuality<StrictDefinition, OptionalInRequired, TData> json)
    {
        public async Task<TData?> ReadAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : default;
        }
        public async Task<JsonReadResult<TData>> ReadResultAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : JsonReadResult<TData>.Missing;
        }

        public async Task WriteAsync(TData value, CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenWriteAsync(cancellationToken).ConfigureAwait(false);
            await JsonSerializer.SerializeAsync(stream, value, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
    }

    extension<TData>(IJsonQuality<ExternalDefinition, OptionalInRequired, TData> json)
    {
        public async Task<TData?> ReadAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : default;
        }
        public async Task<JsonReadResult<TData>> ReadResultAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : JsonReadResult<TData>.Missing;
        }

        public async Task<bool> WriteAsync(TData value, CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenWriteAsync(cancellationToken).ConfigureAwait(false);
            if (stream is not null)
                await JsonSerializer.SerializeAsync(stream, value, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);

            return stream is not null;
        }
    }

    extension<TData>(IJsonQuality<StrictDefinition, OptionalInOptional, TData> json)
    {
        public async Task<TData?> ReadAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : default;
        }
        public async Task<JsonReadResult<TData>> ReadResultAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : JsonReadResult<TData>.Missing;
        }

        public async Task<bool> WriteAsync(TData value, CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenWriteAsync(cancellationToken).ConfigureAwait(false);
            if (stream is not null)
                await JsonSerializer.SerializeAsync(stream, value, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);

            return stream is not null;
        }
    }

    extension<TData>(IJsonQuality<ExternalDefinition, OptionalInOptional, TData> json)
    {
        public async Task<TData?> ReadAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : default;
        }
        public async Task<JsonReadResult<TData>> ReadResultAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : JsonReadResult<TData>.Missing;
        }

        public async Task<bool> WriteAsync(TData value, CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenWriteAsync(cancellationToken).ConfigureAwait(false);
            if (stream is not null)
                await JsonSerializer.SerializeAsync(stream, value, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);

            return stream is not null;
        }
    }
}
