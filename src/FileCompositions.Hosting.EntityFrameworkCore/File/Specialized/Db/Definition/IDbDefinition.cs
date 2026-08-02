using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Quality;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition;

public interface IDbDefinition<TOwnership, TPlacement, TDbContext> : IFileDefinition<TOwnership, TPlacement>,
    IDbQuality<TOwnership, TPlacement, TDbContext>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext
{
    Task InitializeAsync(in TDbContext db, CancellationToken cancellationToken);
}
