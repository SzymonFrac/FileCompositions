using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder.Factory.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Json.Context;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.File.Resource.Specialized.Json.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;
using System.Text.Json;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Abstract;

internal abstract class AbstractJsonDefinition<TOwnership, TNecessity, TData>(FileDefinitionKey key, IJsonResourceContext context, StorageResourceName name, JsonResourceFormatContext format)
    : AbstractJsonDefinition<TData>(context, name, format), IJsonDefinition<TOwnership, TNecessity, TData>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    public FileDefinitionKey Key { get; } = key;
}

internal abstract class AbstractJsonDefinition<TData>(IJsonResourceContext context, StorageResourceName name, JsonResourceFormatContext format)
    : JsonResource<TData>(context, name, format), IJsonDefinition<TData>
{
    public static StorageResourceExtension Extension { get; } = new(".json");

    public static IJsonResource<TData> Convert(IDirectoryLocation directory, StorageResourceName name, Action<IJsonResourceBuilder<TData>>? config = default)
    {
        var factory = new JsonResourceBuilderFactory(new(JsonSerializerOptions.Default));
        var builder = factory.CreateDefault<TData>();
        config?.Invoke(builder);
        var json = builder.Build(directory);
        return json;
    }

    public static IFileResource Convert(IDirectoryLocation directory, StorageResourceName name) =>
        Convert(directory, name);
}
