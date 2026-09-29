using FileCompositions.Core.File.Quality;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Quality;

public interface IUnspecifiedQuality<TOwnership, TPlacement> : IFileQuality<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement;
