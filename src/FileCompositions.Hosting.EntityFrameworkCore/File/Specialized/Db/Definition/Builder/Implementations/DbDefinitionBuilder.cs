using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Abstract;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;

internal sealed class DbDefinitionBuilder<TOwnership, TPlacement, TDbContext> : AbstractDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext
{
    public DbDefinitionBuilder(IDbOptions<TDbContext> options) : base(options) { }
    private DbDefinitionBuilder(IDbOptions<TDbContext> options, FileDefinitionKey? key) : base(options, key) { }

    public override IDbDefinitionBuilder<TNewOwnership, TNewPlacement, TDbContext> Create<TNewOwnership, TNewPlacement>() =>
        new DbDefinitionBuilder<TNewOwnership, TNewPlacement, TDbContext>(Options, Key);

    public override IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }
}
