using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Extension.Some;
using FileCompositions.Core.File.Specialized.Json.Definition.Abstract;
using FileCompositions.Core.File.Specialized.Json.Extension;
using FileCompositions.Core.File.Specialized.Json.Format;
using FileCompositions.Core.File.Specialized.Json.Resource;
using FileCompositions.Core.File.Specialized.Json.Resource.Builder.Factory.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Implementations;

internal sealed class JsonDefinition<TOwnership, TPlacement, TData>(IFileContext context, FileDefinitionKey key, string name, JsonFormat format, TData? @default = default) :
    AbstractJsonDefinition<TOwnership, TPlacement, TData>(context, key, name, format, @default)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;

internal sealed class JsonDefinition : IJsonDefinition
{
    public static SomeFileExtension Extension { get; } = new JsonExtension();
    private JsonDefinition() { }

    public static IJsonResource<TData> Convert<TData>(in IFileContext context, string name) =>
        JsonResourceBuilderFactory.Default
            .CreateDefault<TData>()
            .WithName(name)
            .Build(context);
}
