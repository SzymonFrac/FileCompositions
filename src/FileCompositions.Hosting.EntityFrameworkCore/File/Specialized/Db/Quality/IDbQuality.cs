using FileCompositions.Core.File.Quality;
using FileCompositions.Core.Quality;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Quality;

public interface IDbQuality<TOwnership, TPlacement, TDbContext> : IFileQuality<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
    where TDbContext : DbContext;