using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Specialized.Json.Extensions;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.Storage.ResourceName;
using System.Text.Json;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Implementations;

internal class JsonResource<TData>(IFileContext context, string name, JsonResourceFormatContext format) :
    AbstractFileResource(context, StorageResourceName.CreateJson(name)), IJsonResource<TData>
{
    private readonly JsonResourceFormatContext _format = format;

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
