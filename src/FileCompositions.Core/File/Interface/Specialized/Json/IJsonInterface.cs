using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Interface.Specialized.Json;

public interface IJsonInterface<TOwnership, TPlacement, TData> : IFileInterface<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    JsonInterfaceFormat Format { get; }
}
