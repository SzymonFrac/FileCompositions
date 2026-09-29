using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Init.Policy;

internal interface IUnspecifiedInitPolicy<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    Func<CancellationToken, Task> GetPolicy(IUnspecifiedDefinition<TOwnership, TPlacement> init);
}
