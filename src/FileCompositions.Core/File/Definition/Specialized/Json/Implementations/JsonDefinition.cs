using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Abstract;
using FileCompositions.Core.File.Resource.Specialized.Json.Context;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Implementations;

internal class JsonDefinition<TOwnership, TNecessity, TData>(FileDefinitionKey key, IJsonResourceContext context, StorageResourceName name, JsonResourceFormatContext format) :
    AbstractJsonDefinition<TOwnership, TNecessity, TData>(key, context, name, format)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
