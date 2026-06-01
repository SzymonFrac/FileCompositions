using FileCompositions.Core.File.Definition.Init;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Init;

public interface IDbDefinitionInit<TOwnership, TPlacement, TDbContext> : IFileDefinitionInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext
{
    internal ValueTask InitializeAsync(in TDbContext db, CancellationToken cancellationToken = default);
}