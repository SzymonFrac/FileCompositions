using FileCompositions.Core.File.Interface;
using FileCompositions.Core.File.Interface.Specialized.Json;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;
using LanguageExt;
using System.Text.Json;

namespace FileCompositions.Core.LanguageExt.File.Interface.Specialized.Json;

public static class LanguageExtJsonInterface
{
    extension<TOwnership, TData>(IJsonInterface<TOwnership, RequiredInRequired, TData> json)
        where TOwnership : DefinitionOwnership
    {
        public async Task<Option<TData>> ReadOptionAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
        }
    }

    extension<TData>(IJsonInterface<StrictDefinition, OptionalInRequired, TData> json)
    {
        public async Task<Option<TData>> ReadOptionAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : default;
        }
    }

    extension<TData>(IJsonInterface<ExternalDefinition, OptionalInRequired, TData> json)
    {
        public async Task<Option<TData>> ReadOptionAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : default;
        }
    }

    extension<TData>(IJsonInterface<StrictDefinition, OptionalInOptional, TData> json)
    {
        public async Task<Option<TData>> ReadOptionAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : default;
        }
    }

    extension<TData>(IJsonInterface<ExternalDefinition, OptionalInOptional, TData> json)
    {
        public async Task<Option<TData>> ReadOptionAsync(CancellationToken cancellationToken = default)
        {
            await using var stream = await json.OpenReadAsync(cancellationToken).ConfigureAwait(false);
            return stream is not null
                ? await JsonSerializer.DeserializeAsync<TData>(stream, json.Format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false)
                : default;
        }
    }
}
