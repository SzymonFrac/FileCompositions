using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Abstract;
using FileCompositions.Core.File.Interface.Specialized.Json.Builder;
using FileCompositions.Core.File.Interface.Specialized.Json.Builder.Factory.Implementations;
using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;
using System.Text.Json;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Implementations;

internal class JsonDefinition<TOwnership, TPlacement, TData>(IFileContext context, FileDefinitionKey key, string name, JsonInterfaceFormat format) :
    AbstractJsonDefinition<TOwnership, TPlacement, TData>(context, key, name, format)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;

internal sealed class JsonDefinition : IJsonDefinition
{
    public static StorageResourceExtension Extension { get; } = new(".json");
    private JsonDefinition() { }

    public static IJsonResource<TData> Convert<TData>(IDirectoryLocation directory, StorageResourceName name, Action<IJsonResourceBuilder<TData>>? config = default)
    {
        var factory = new JsonResourceBuilderFactory(new(JsonSerializerOptions.Default));
        var builder = factory.CreateDefault<TData>();
        config?.Invoke(builder);

        var context = new FileContext(directory);
        var json = builder.Build(context);
        return json;
    }

    public static IFileResource Convert(IDirectoryLocation directory, StorageResourceName name) =>
        Convert(directory, name);
}
