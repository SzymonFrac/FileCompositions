using FileCompositions.Core.Database.File.Definition.Db.Extensions;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Init.Policy;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Abstract;

internal abstract class AbstractDbDefinition<TOwnership, TPlacement, TDbContext>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractFileDefinition<TOwnership, TPlacement>(context, key, FileSystemResourceName.CreateDb(name)), IDbDefinition<TOwnership, TPlacement, TDbContext>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext
{
    public required IDbInitPolicy<TOwnership, TPlacement, TDbContext> InitPolicy { get; init; }

    public ValueTask InitializeAsync(in TDbContext db, CancellationToken cancellationToken) =>
        InitPolicy.GetPolicy(this).Invoke(db, cancellationToken);

    public override ValueTask InitializeAsync(CancellationToken cancellationToken = default) =>
        throw new InvalidOperationException();
}
