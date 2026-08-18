using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.No.Definition.Builder;

public partial interface INoFileDefinitionBuilder<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    internal INoFileDefinitionBuilder<TNewOwnership, TNewPlacement> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : DefinitionOwnership
        where TNewPlacement : DefinitionPlacement;

    INoFileDefinitionBuilder<TOwnership, TPlacement> WithKey(FileDefinitionKey key);
}
