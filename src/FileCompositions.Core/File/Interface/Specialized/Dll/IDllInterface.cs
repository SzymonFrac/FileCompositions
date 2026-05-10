using FileCompositions.Core.Quality.Placement;
using System.Reflection;

namespace FileCompositions.Core.File.Interface.Specialized.Dll;

public interface IDllInterface<TPlacement> : IFileInterface<TPlacement>
    where TPlacement : DefinitionPlacement
{
    Assembly? Assembly { get; internal set; }
}
