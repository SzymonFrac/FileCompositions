using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.No.Definition.Builder.Implementations;

internal sealed partial class NoFileDefinitionBuilder<TOwnership, TPlacement> : INoFileDefinitionBuilder<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public FileDefinitionKey BuildKey() => _key ?? throw new NullReferenceException("Key was not set in file definition builder.");
}
