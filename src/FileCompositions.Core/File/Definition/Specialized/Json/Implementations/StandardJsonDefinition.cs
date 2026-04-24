using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Abstract;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Implementations;

internal class StandardJsonDefinition<TOwnership, TNecessity, TData>(FileDefinitionKey key, IFileContext context, string name, JsonResourceFormatContext format) :
    JsonDefinition<TOwnership, TNecessity, TData>(key, context, name, format)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
