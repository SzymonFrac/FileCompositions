using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Init.Policy;

internal interface IJsonInitPolicy<TOwnership, TPlacement, TData>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    Func<CancellationToken, Task> GetPolicy(IJsonDefinition<TOwnership, TPlacement, TData> init);
}
