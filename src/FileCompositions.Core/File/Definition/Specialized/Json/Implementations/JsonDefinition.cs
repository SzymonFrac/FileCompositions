using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Abstract;
using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder.Factory.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Resource.Extension;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Implementations;

internal class JsonDefinition<TOwnership, TPlacement, TData>(IFileContext context, FileDefinitionKey key, string name, JsonInterfaceFormat format) :
    AbstractJsonDefinition<TOwnership, TPlacement, TData>(context, key, name, format)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;

internal sealed class JsonDefinition : IJsonDefinition
{
    public static StorageResourceExtension Extension { get; } = new(".json");
    private JsonDefinition() { }

    public static IJsonResource<TData> Convert<TData>(in IFileContext context, string name) =>
        JsonResourceBuilderFactory.Default
            .CreateDefault<TData>()
            .WithName(name)
            .Build(context);
}
