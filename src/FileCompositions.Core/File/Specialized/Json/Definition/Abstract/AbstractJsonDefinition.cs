using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Json.Definition.Init.Policy;
using FileCompositions.Core.File.Specialized.Json.Format;
using FileCompositions.Core.File.Specialized.Json.Name.Ext;
using FileCompositions.Core.FileSystem.Name;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Abstract;

internal abstract class AbstractJsonDefinition<TOwnership, TPlacement, TData>(IFileContext context, FileDefinitionKey key, string name, JsonFormat format, TData? @default = default)
    : AbstractFileDefinition<TOwnership, TPlacement>(context, key, FileSystemFilename.CreateJson(name)), IJsonDefinition<TOwnership, TPlacement, TData>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public JsonFormat Format { get; } = format;
    public TData? Default { get; } = @default;

    public required IJsonInitPolicy<TOwnership, TPlacement, TData> InitPolicy { get; init; }

    public override Task InitializeAsync(CancellationToken cancellationToken = default) =>
        InitPolicy.GetPolicy(this).Invoke(cancellationToken);
}
