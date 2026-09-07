using FileCompositions.Core.File.Quality;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Quality;

public interface IDbQuality<TOwnership, TPlacement> : IFileQuality<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement;