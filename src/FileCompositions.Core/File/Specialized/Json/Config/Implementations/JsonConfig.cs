using FileCompositions.Core.File.Specialized.Json.Definition.Descriptor;
using FileCompositions.Core.File.Specialized.Json.Definition.Implementations;
using FileCompositions.Core.File.Specialized.Json.Definition.Init.Policy.Implementations;
using FileCompositions.Core.File.Specialized.Json.Format;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Config.Implementations;

internal sealed class JsonConfig<TData> : IJsonConfig<TData>
{
    private string? name;
    private JsonFormat format = JsonFormat.Default;
    private TData? @default;

    public IJsonConfig<TData> WithName(string n)
    {
        name = n;
        return this;
    }
    public IJsonConfig<TData> UseSerializerOptions(JsonSerializerOptions options)
    {
        format = format with { JsonSerializerOptions = options };
        return this;
    }
    public IJsonConfig<TData> UseDefault(TData d)
    {
        @default = d;
        return this;
    }



    public JsonDefinitionDescriptor<TOwnership, TPlacement, TData> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        if (name is null)
            throw new NullReferenceException("File must have a name.");

        return (key, context) => new JsonDefinition<TOwnership, TPlacement, TData>(context, key, name, format, @default)
        {
            InitPolicy = new DefaultJsonInitPolicy<TOwnership, TPlacement, TData>()
        };
    }
}
