using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.File.Resource.Specialized.Json.Context;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.Storage.ResourceName;
using System.Text.Json;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Implementations;

internal class JsonResource<TData>(IJsonResourceContext context, StorageResourceName name, JsonResourceFormatContext format) :
    AbstractFileResource(context, name), IJsonResource<TData>
{
    private readonly JsonResourceFormatContext _format = format;
    new public IJsonResourceContext Context { get; } = context;

    public async Task<TData?> Read(CancellationToken cancellationToken = default)
    {
        await using var stream = await OpenReadAsync(cancellationToken).ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<TData>(stream, _format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
    }

    public async Task Write(TData value, CancellationToken cancellationToken = default)
    {
        await using var stream = await OpenWriteAsync(cancellationToken).ConfigureAwait(false);
        await JsonSerializer.SerializeAsync(stream, value, _format.JsonSerializerOptions, cancellationToken).ConfigureAwait(false);
    }
}
