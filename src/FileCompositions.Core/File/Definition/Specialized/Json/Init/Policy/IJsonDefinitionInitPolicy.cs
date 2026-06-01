using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Init.Policy;

internal interface IJsonDefinitionInitPolicy<TOwnership, TPlacement, TData>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    Func<CancellationToken, ValueTask> GetPolicy(IJsonDefinitionInit<TOwnership, TPlacement, TData> init);
}
