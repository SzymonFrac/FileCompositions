using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Descriptor;

//internal interface IJsonDefinitionDescriptor<TOwnership, TPlacement, TData>
//    : IFileDefinitionDescriptor<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>>
//        where TOwnership : DefinitionOwnership
//        where TPlacement : DefinitionPlacement;

internal delegate IJsonDefinition<TOwnership, TPlacement, TData> JsonDefinitionDescriptor<TOwnership, TPlacement, TData>(FileDefinitionKey key, IFileContext context)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement;