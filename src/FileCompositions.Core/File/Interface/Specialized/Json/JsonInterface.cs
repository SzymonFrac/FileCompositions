using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Text.Json;

namespace FileCompositions.Core.File.Interface.Specialized.Json;

public static class JsonInterface
{
    extension<TOwnership, TData>(IJsonInterface<TOwnership, RequiredInRequired, TData> json)
        where TOwnership : DefinitionOwnership
    {
        public async Task<TData?> Read(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<TData?>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
        public async Task Write(TData value, CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenWriteAsync(cancellationToken).ConfigureAwait(false);
            await JsonSerializer.SerializeAsync(stream, value, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
    }

    extension<TData>(IJsonInterface<StrictDefinition, OptionalInRequired, TData> json)
    {
        public async Task<TData?> Read(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : default;
        }
        public async Task Write(TData value, CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenWriteAsync(cancellationToken).ConfigureAwait(false);
            await JsonSerializer.SerializeAsync(stream, value, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
    }

    extension<TData>(IJsonInterface<ExternalDefinition, OptionalInRequired, TData> json)
    {
        public async Task<TData?> Read(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : default;
        }
        public async Task<bool> Write(TData value, CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenWriteAsync(cancellationToken).ConfigureAwait(false);
            if (stream is not null)
                await JsonSerializer.SerializeAsync(stream, value, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);

            return stream is not null;
        }
    }

    extension<TData>(IJsonInterface<StrictDefinition, OptionalInOptional, TData> json)
    {
        public async Task<TData?> Read(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : default;
        }
        public async Task<bool> Write(TData value, CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenWriteAsync(cancellationToken).ConfigureAwait(false);
            if (stream is not null)
                await JsonSerializer.SerializeAsync(stream, value, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            
            return stream is not null;
        }
    }

    extension<TData>(IJsonInterface<ExternalDefinition, OptionalInOptional, TData> json)
    {
        public async Task<TData?> Read(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : default;
        }
        public async Task<bool> Write(TData value, CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenWriteAsync(cancellationToken).ConfigureAwait(false);
            if (stream is not null)
                await JsonSerializer.SerializeAsync(stream, value, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);

            return stream is not null;
        }
    }
}