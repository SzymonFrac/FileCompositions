using FileCompositions.Core.Database.File.Specialized.Db.Name.Ext;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.FileSystem.Name;
using FileCompositions.Core.Quality;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Init.Policy;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Abstract;

internal abstract class AbstractDbDefinition<TOwnership, TPlacement, TDbContext>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractFileDefinition<TOwnership, TPlacement>(context, key, FileSystemFilename.CreateDb(name)), IDbDefinition<TOwnership, TPlacement, TDbContext>
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDbContext : DbContext
{
    public required IDbInitPolicy<TOwnership, TPlacement, TDbContext> InitPolicy { get; init; }

    public Task InitializeAsync(in TDbContext db, CancellationToken cancellationToken) =>
        InitPolicy.GetPolicy(this).Invoke(db, cancellationToken);

    public override Task InitializeAsync(CancellationToken cancellationToken = default) =>
        throw new InvalidOperationException();
}
