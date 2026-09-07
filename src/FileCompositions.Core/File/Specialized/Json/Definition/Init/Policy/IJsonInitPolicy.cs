using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Init.Policy;

internal interface IJsonInitPolicy<TOwnership, TPlacement, TData>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    Func<CancellationToken, Task> GetPolicy(IJsonDefinition<TOwnership, TPlacement, TData> init);
}
