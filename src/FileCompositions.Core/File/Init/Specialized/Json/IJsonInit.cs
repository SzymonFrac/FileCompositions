using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Init.Specialized.Json;

public interface IJsonInit<TOwnership, TPlacement, TData> : IFileInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    TData? Default { get; }

    internal JsonInterfaceFormat Format { get; }
}
