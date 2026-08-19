using FileCompositions.Core.File.Options.Abstract;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Options.Abstract;

internal abstract partial class AbstractJsonOptions<TData> : AbstractFileOptions<IJsonOptions<TData>>, IJsonOptions<TData>
{
    protected JsonSerializerOptions SerializerOptions { get; set; } = JsonSerializerOptions.Default;

    protected override IJsonOptions<TData> This() => this;

    public IJsonOptions<TData> UseSerializerOptions(JsonSerializerOptions serializerOptions)
    {
        SerializerOptions = serializerOptions;
        return this;
    }
}
