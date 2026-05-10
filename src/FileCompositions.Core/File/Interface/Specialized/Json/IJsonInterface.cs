using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Interface.Specialized.Json;

public interface IJsonInterface<TPlacement, TData> : IFileInterface<TPlacement>
    where TPlacement : DefinitionPlacement
{
    JsonInterfaceFormat Format { get; }
}
