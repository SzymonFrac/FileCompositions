using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.No.Definition.Builder.Implementations;

internal sealed partial class NoFileDefinitionBuilder<TOwnership, TPlacement> : INoFileDefinitionBuilder<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    public FileDefinitionKey BuildKey() => _key ?? throw new NullReferenceException("Key was not set in file definition builder.");
}
