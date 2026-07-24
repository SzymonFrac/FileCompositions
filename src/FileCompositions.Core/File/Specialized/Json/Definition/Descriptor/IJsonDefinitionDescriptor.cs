using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Specialized.Json.Definition;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Descriptor;

internal interface IJsonDefinitionDescriptor<TOwnership, TPlacement, TData>
    : IFileDefinitionDescriptor<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
