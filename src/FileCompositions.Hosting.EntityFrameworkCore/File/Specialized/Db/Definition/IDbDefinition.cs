using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Quality;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition;

public interface IDbDefinition<TOwnership, TPlacement, TDbContext> : IFileDefinition<TOwnership, TPlacement>,
    IDbQuality<TOwnership, TPlacement, TDbContext>
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDbContext : DbContext
{
    Task InitializeAsync(in TDbContext db, CancellationToken cancellationToken);
}
