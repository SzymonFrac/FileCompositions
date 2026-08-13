using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Abstract;
using FileCompositions.Core.Database.File.Specialized.Db.Options;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;

internal sealed class DbDefinitionBuilder<TOwnership, TPlacement> : AbstractDbDefinitionBuilder<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public DbDefinitionBuilder(IDbOptions options) : base(options) { }
    private DbDefinitionBuilder(IDbOptions options, FileDefinitionKey? key) : base(options, key) { }

    public override IDbDefinitionBuilder<TNewOwnership, TNewPlacement> Create<TNewOwnership, TNewPlacement>() =>
        new DbDefinitionBuilder<TNewOwnership, TNewPlacement>(Options, Key);

    public override IDbDefinitionBuilder<TOwnership, TPlacement> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }
}
