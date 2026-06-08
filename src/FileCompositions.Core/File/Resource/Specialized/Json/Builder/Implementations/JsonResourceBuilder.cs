using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.File.Resource.Builder.Abstract;
using FileCompositions.Core.File.Resource.Specialized.Json.Implementations;
using System.Text.Json;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Builder.Implementations;

internal sealed class JsonResourceBuilder<TData>
    : AbstractFileResourceBuilder, IJsonResourceBuilder<TData>
{
    private JsonInterfaceFormat format = JsonInterfaceFormat.Default;

    public IJsonResourceBuilder<TData> WithName(string name)
    {
        Name = name;
        return this;
    }
    public IJsonResourceBuilder<TData> UseSerializerOptions(JsonSerializerOptions options)
    {
        format = format with { JsonSerializerOptions = options };
        return this;
    }

    public IJsonResource<TData> Build(in IFileContext context)
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var json = new JsonResource<TData>(context, Name, format);
        return json;
    }
}
