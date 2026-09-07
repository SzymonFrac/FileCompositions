using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Ext;
using FileCompositions.Core.Database.File.Specialized.Db.Options;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Abstract;

internal abstract partial class AbstractDbDefinitionBuilder<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner, Action<IDbOptions> config) :
    IDbDefinitionBuilder<TOwnership, TPlacement>
        where TOwnership : Ownership
        where TPlacement : Placement
{
    private readonly INoFileDefinitionBuilder<TOwnership, TPlacement> _inner = inner;
    private readonly Action<IDbOptions> _config = config;

    public IDbDefinitionBuilder<TOwnership, TPlacement> WithKey(FileDefinitionKey key) =>
        _inner.WithKey(key).Db(_config);
}
