using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Descriptor.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Implementations;
using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Descriptor.Implementations;

internal class JsonDefinitionDescriptor<TOwnership, TPlacement, TData>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name, JsonInterfaceFormat format)
    : FileDefinitionDescriptor<IJsonDefinition<TOwnership, TPlacement, TData>, TOwnership, TPlacement>(directoryKey, key, name),
    IJsonDefinitionDescriptor<TOwnership, TPlacement, TData>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    private readonly JsonInterfaceFormat format = format;

    public override IJsonDefinition<TOwnership, TPlacement, TData> Activate(in IFileContext context) =>
        new JsonDefinition<TOwnership, TPlacement, TData>(context, Key, Name, format);
}
