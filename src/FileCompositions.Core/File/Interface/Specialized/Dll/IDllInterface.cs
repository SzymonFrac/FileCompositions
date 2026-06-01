using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using System.Reflection;

namespace FileCompositions.Core.File.Interface.Specialized.Dll;

public interface IDllInterface<TOwnership, TPlacement> : IFileInterface<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    Assembly? Assembly { get; internal set; }
}
