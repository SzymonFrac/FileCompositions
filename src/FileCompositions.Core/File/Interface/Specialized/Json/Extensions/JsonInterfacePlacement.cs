using FileCompositions.Core.File.Interface.Extensions;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Text.Json;

namespace FileCompositions.Core.File.Interface.Specialized.Json.Extensions;

public static class JsonInterfacePlacement
{
    extension<TData>(IJsonInterface<RequiredInRequired, TData> json)
    {
        public async Task<TData?> Read(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
        public async Task Write(TData value, CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenWriteAsync(cancellationToken).ConfigureAwait(false);
            await JsonSerializer.SerializeAsync(stream, value, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
    }

    extension<TData>(IJsonInterface<OptionalInRequired, TData> json)
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

    extension<TData>(IJsonInterface<OptionalInOptional, TData> json)
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
            if (stream is null)
                return false;
            
            await JsonSerializer.SerializeAsync(stream, value, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
