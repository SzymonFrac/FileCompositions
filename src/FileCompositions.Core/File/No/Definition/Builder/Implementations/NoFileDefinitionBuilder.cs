using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.No.Definition.Builder.Implementations;

internal sealed partial class NoFileDefinitionBuilder<TOwnership, TPlacement> : INoFileDefinitionBuilder<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    private readonly FileDefinitionKey? _key;

    public NoFileDefinitionBuilder() { }
    private NoFileDefinitionBuilder(FileDefinitionKey? key) => _key = key;

    public INoFileDefinitionBuilder<TNewOwnership, TNewPlacement> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : DefinitionOwnership
        where TNewPlacement : DefinitionPlacement =>
            new NoFileDefinitionBuilder<TNewOwnership, TNewPlacement>(_key);

    public INoFileDefinitionBuilder<TOwnership, TPlacement> WithKey(FileDefinitionKey key) =>
        new NoFileDefinitionBuilder<TOwnership, TPlacement>(key);

}
