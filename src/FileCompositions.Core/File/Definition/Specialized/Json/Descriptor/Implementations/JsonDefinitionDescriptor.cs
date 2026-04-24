using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Abstract;
using FileCompositions.Core.File.Definition.Specialized.Json.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Descriptor.Implementations;

internal class JsonDefinitionDescriptor<TOwnership, TNecessity, TData>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name, JsonResourceFormatContext format)
    : IJsonDefinitionDescriptor<TOwnership, TNecessity, TData>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    private readonly string name = name;
    private readonly JsonResourceFormatContext format = format;
    public DirectoryDefinitionKey DirectoryKey { get; } = directoryKey;
    public FileDefinitionKey Key { get; private set; } = key;
    public FileDefinitionKey WithKeyIfNull(FileDefinitionKey k)
    {
        if (Key == default)
            Key = k;
        return Key;
    }

    public JsonDefinition<TOwnership, TNecessity, TData> Activate(in IFileContext context) =>
        new StandardJsonDefinition<TOwnership, TNecessity, TData>(Key, context, name, format);
}
