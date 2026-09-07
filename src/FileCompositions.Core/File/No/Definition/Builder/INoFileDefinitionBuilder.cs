using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.No.Definition.Builder;

public partial interface INoFileDefinitionBuilder<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    internal INoFileDefinitionBuilder<TNewOwnership, TNewPlacement> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : Ownership
        where TNewPlacement : Placement;

    INoFileDefinitionBuilder<TOwnership, TPlacement> WithKey(FileDefinitionKey key);
}
