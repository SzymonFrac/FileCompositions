using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Descriptor;

internal interface IDllDefinitionDescriptor<TOwnership, TPlacement>
    : IFileDefinitionDescriptor<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;