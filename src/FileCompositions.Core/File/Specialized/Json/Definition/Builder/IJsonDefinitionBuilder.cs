using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder;

public interface IJsonDefinitionBuilder<TOwnership, TPlacement, TData>
    : IFileDefinitionBuilder<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>, IJsonDefinitionBuilder<TOwnership, TPlacement, TData>>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    internal IJsonDefinitionBuilder<TNewOwnership, TNewPlacement, TData> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : DefinitionOwnership
        where TNewPlacement : DefinitionPlacement;
}
