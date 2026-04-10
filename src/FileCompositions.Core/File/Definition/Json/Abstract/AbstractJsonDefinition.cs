using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Resource.Specialized;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder.Factory.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Json.Context;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.File.Resource.Specialized.Json.Implementations;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;
using System.Text.Json;

namespace FileCompositions.Core.File.Definition.Json.Abstract;

internal abstract class AbstractJsonDefinition<TData>(FileDefinitionKey key, IJsonFileResourceContext context, StorageResourceName name, JsonFileResourceFormatContext format)
    : JsonFileResource<TData>(context, name, format), IJsonDefinition<TData>
{
    public static StorageResourceExtension Extension { get; } = new(".json");
    public FileDefinitionKey Key { get; } = key;

    public static IJsonFileResource<TData> Convert(IDirectoryLocation directory, StorageResourceName name, Action<IJsonFileResourceBuilder<TData>>? config = default)
    {
        var factory = new JsonFileResourceBuilderFactory(JsonSerializerOptions.Default);
        var builder = factory.CreateDefault<TData>(name.Value);
        config?.Invoke(builder);
        var json = builder.Build(directory);
        return json;
    }

    public static ISpecializedFileResource Convert(IDirectoryLocation directory, StorageResourceName name) =>
        Convert(directory, name);
}
