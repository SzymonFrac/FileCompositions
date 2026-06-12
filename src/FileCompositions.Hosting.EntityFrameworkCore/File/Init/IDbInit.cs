using FileCompositions.Core.File.Init;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Init;

public interface IDbInit<TOwnership, TPlacement, TDbContext> : IFileInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext
{
    internal ValueTask InitializeAsync(in TDbContext db, CancellationToken cancellationToken = default);
}