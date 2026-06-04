using FileCompositions.Core.File.Definition.Init;
using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Init;

public interface IJsonDefinitionInit<TOwnership, TPlacement, TData> : IFileDefinitionInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    TData? Default { get; }

    internal JsonInterfaceFormat Format { get; }
}
