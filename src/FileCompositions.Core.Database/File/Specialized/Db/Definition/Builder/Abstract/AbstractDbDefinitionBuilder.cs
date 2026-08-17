using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Ext;
using FileCompositions.Core.Database.File.Specialized.Db.Options;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Abstract;

internal abstract partial class AbstractDbDefinitionBuilder<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner, Action<IDbOptions> config) :
    IDbDefinitionBuilder<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    private readonly INoFileDefinitionBuilder<TOwnership, TPlacement> _inner = inner;
    private readonly Action<IDbOptions> _config = config;

    //public IFileDefinitionBuilder<TNewOwnership, TNewPlacement, IDbOptions> Create<TNewOwnership, TNewPlacement>()
    //    where TNewOwnership : DefinitionOwnership
    //    where TNewPlacement : DefinitionPlacement =>
    //        _inner.Create<TNewOwnership, TNewPlacement>()
    //            .Db(_config);

    public IDbDefinitionBuilder<TOwnership, TPlacement> WithKey(FileDefinitionKey key) =>
        _inner.WithKey(key).Db(_config);
}
