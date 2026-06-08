using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Extensions;
using FileCompositions.Core.File.Definition.Specialized.Json.Init;
using FileCompositions.Core.File.Definition.Specialized.Json.Init.Policy;
using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Abstract;

internal abstract class AbstractJsonDefinition<TOwnership, TPlacement, TData>(IFileContext context, FileDefinitionKey key, string name, JsonInterfaceFormat format, TData? @default = default)
    : AbstractFileDefinition<TOwnership, TPlacement>(context, key, FileSystemResourceName.CreateJson(name)), IJsonDefinition<TOwnership, TPlacement, TData>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public JsonInterfaceFormat Format { get; } = format;
    public TData? Default { get; } = @default;

    public required IJsonDefinitionInitPolicy<TOwnership, TPlacement, TData> InitPolicy { get; init; }

    public override ValueTask InitializeAsync(CancellationToken cancellationToken = default) =>
        InitPolicy.GetPolicy(this).Invoke(cancellationToken);
}
