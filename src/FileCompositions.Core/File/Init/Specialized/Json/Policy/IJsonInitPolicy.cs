using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Init.Specialized.Json.Policy;

internal interface IJsonInitPolicy<TOwnership, TPlacement, TData>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    Func<CancellationToken, ValueTask> GetPolicy(IJsonInit<TOwnership, TPlacement, TData> init);
}
