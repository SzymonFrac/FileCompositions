using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.No.Definition.Builder.Implementations;

internal sealed partial class NoDefinitionBuilder<TOwnership, TPlacement>
    : AbstractFileDefinitionBuilder<TOwnership, TPlacement, INoDefinition<TOwnership, TPlacement>, INoDefinitionBuilder<TOwnership, TPlacement>>,
    INoDefinitionBuilder<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public NoDefinitionBuilder() { }
    private NoDefinitionBuilder(FileDefinitionKey? key) : base(key) { }

    public INoDefinitionBuilder<TNewOwnership, TNewPlacement> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : DefinitionOwnership
        where TNewPlacement : DefinitionPlacement =>
            new NoDefinitionBuilder<TNewOwnership, TNewPlacement>(Key);

    public override INoDefinitionBuilder<TOwnership, TPlacement> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }

}
