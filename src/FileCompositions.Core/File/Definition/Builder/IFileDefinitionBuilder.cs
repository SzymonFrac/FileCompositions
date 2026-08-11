using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Builder;

// But what if you put placement here?
// So then you say that the first is static, and the second is the mutable....
public partial interface IFileDefinitionBuilder<TOwnership, TNecessity, TBuilder>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBuilder : IFileDefinitionBuilder<TOwnership, TNecessity, TBuilder>
{
    TBuilder WithKey(FileDefinitionKey key);
};
