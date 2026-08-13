using FileCompositions.Core.Database.File.Specialized.Db.Options;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Abstract;

internal abstract partial class AbstractDbDefinitionBuilder<TOwnership, TPlacement>
    : AbstractFileDefinitionBuilder<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>, IDbDefinitionBuilder<TOwnership, TPlacement>>,
    IDbDefinitionBuilder<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    protected IDbOptions Options { get; set; }

    public AbstractDbDefinitionBuilder(IDbOptions options) => Options = options;
    protected AbstractDbDefinitionBuilder(IDbOptions options, FileDefinitionKey? key = default) : base(key) => Options = options;

    public abstract IDbDefinitionBuilder<TNewOwnership, TNewPlacement> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : DefinitionOwnership
        where TNewPlacement : DefinitionPlacement;
}
