using FileCompositions.Core.File.Quality;
using FileCompositions.Core.Quality;
using System.Reflection;

namespace FileCompositions.Core.File.Specialized.Dll.Quality;

public interface IDllQuality<TOwnership, TPlacement> : IFileQuality<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    Assembly? Assembly { get; internal set; }
}
