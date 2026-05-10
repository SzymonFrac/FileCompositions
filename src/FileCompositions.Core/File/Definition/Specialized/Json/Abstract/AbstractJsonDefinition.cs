using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Extensions;
using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Abstract;

internal abstract class AbstractJsonDefinition<TOwnership, TPlacement, TData>(IFileContext context, FileDefinitionKey key, string name, JsonInterfaceFormat format)
    : FileDefinition<TOwnership, TPlacement>(context, key, StorageResourceName.CreateJson(name)), IJsonDefinition<TOwnership, TPlacement, TData>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public JsonInterfaceFormat Format { get; } = format;
}
