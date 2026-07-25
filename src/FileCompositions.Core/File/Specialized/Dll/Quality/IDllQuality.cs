using FileCompositions.Core.File.Quality;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using System.Reflection;

namespace FileCompositions.Core.File.Specialized.Dll.Quality;

public interface IDllQuality<TOwnership, TPlacement> : IFileQuality<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    Assembly? Assembly { get; internal set; }
}
