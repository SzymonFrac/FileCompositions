using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Builder;

public partial interface IFileDefinitionBuilder<TOwnership, TPlacement, TBuilder>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TBuilder : IFileDefinitionBuilder<TOwnership, TPlacement, TBuilder>
{
    TBuilder WithKey(FileDefinitionKey key);
};
