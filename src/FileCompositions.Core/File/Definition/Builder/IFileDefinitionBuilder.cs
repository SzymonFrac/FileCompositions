using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Definition.Builder;

public partial interface IFileDefinitionBuilder<TOwnership, TPlacement, TBuilder>
    where TOwnership : Ownership
    where TPlacement : Placement
    where TBuilder : IFileDefinitionBuilder<TOwnership, TPlacement, TBuilder>
{
    TBuilder WithKey(FileDefinitionKey key);
};
