using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder;

public interface IDllDefinitionBuilder<TOwnership, TPlacement>
    : IFileDefinitionBuilder<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>, IDllDefinitionBuilder<TOwnership, TPlacement>>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    internal IDllDefinitionBuilder<TNewOwnership, TNewPlacement> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : DefinitionOwnership
        where TNewPlacement : DefinitionPlacement;
}
