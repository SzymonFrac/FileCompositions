using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Descriptor;

internal interface IJsonDefinitionDescriptor<TOwnership, TPlacement, TData>
    : IFileDefinitionDescriptor<IJsonDefinition<TOwnership, TPlacement, TData>, TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
