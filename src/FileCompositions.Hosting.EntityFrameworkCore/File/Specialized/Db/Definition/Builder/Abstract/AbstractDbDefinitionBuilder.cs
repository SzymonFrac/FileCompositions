using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Ext;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Abstract;

internal abstract partial class AbstractDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner, Action<IDbOptions<TDbContext>> config) :
    IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDbContext : DbContext
{
    private readonly INoFileDefinitionBuilder<TOwnership, TPlacement> _inner = inner;
    private readonly Action<IDbOptions<TDbContext>> _config = config;

    public IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext> WithKey(FileDefinitionKey key) =>
        _inner.WithKey(key).Db(_config);
}