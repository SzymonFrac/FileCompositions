using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Builder;

public partial interface IFileDefinitionBuilder<TOwnership, TPlacement, TBuilder>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TBuilder : IFileDefinitionBuilder<TOwnership, TPlacement, TBuilder>
{
    //internal IFileDefinitionBuilder<TNewOwnership, TNewPlacement, TBuilder> Create<TNewOwnership, TNewPlacement>()
    //    where TNewOwnership : DefinitionOwnership
    //    where TNewPlacement : DefinitionPlacement;
    
    TBuilder WithKey(FileDefinitionKey key);
};
