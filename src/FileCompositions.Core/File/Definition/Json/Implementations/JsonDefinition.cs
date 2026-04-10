using FileCompositions.Core.File.Definition.Json.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Resource.Specialized.Json.Context;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Json.Implementations;

internal class JsonDefinition<TData>(FileDefinitionKey key, IJsonFileResourceContext context, StorageResourceName name, JsonFileResourceFormatContext format) :
    AbstractJsonDefinition<TData>(key, context, name, format);
