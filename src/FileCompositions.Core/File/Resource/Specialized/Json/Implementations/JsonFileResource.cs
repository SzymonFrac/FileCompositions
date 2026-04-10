using FileCompositions.Core.File.Resource.Specialized.Abstract;
using FileCompositions.Core.File.Resource.Specialized.Json.Context;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.Storage.ResourceName;
using System.Text.Json;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Implementations;

internal class JsonFileResource<TData>(IJsonFileResourceContext context, StorageResourceName name, JsonFileResourceFormatContext format) :
    AbstractSpecializedFileResource(context, name), IJsonFileResource<TData>
{
    private readonly JsonFileResourceFormatContext _format = format;
    new public IJsonFileResourceContext Context { get; } = context;

    public async Task<TData?> Read(CancellationToken cancellationToken = default)
    {
        await using var stream = await OpenReadAsync().ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<TData>(stream, _format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
    }

    public async Task Write(TData value, CancellationToken cancellationToken = default)
    {
        await using var stream = await OpenWriteAsync().ConfigureAwait(false);
        await JsonSerializer.SerializeAsync(stream, value, _format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
    }
}
