using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.No.Definition.Builder.Implementations;

internal sealed partial class NoFileDefinitionBuilder<TOwnership, TPlacement> : INoFileDefinitionBuilder<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    private readonly FileDefinitionKey? _key;

    public NoFileDefinitionBuilder() { }
    private NoFileDefinitionBuilder(FileDefinitionKey? key) => _key = key;

    public INoFileDefinitionBuilder<TNewOwnership, TNewPlacement> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : Ownership
        where TNewPlacement : Placement =>
            new NoFileDefinitionBuilder<TNewOwnership, TNewPlacement>(_key);

    public INoFileDefinitionBuilder<TOwnership, TPlacement> WithKey(FileDefinitionKey key) =>
        new NoFileDefinitionBuilder<TOwnership, TPlacement>(key);

}
