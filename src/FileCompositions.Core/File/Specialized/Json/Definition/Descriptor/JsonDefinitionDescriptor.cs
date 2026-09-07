using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Descriptor;

internal delegate IJsonDefinition<TOwnership, TPlacement, TData> JsonDefinitionDescriptor<TOwnership, TPlacement, TData>(FileDefinitionKey key, IFileContext context)
    where TOwnership : Ownership
    where TPlacement : Placement;