using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Init.Policy;

internal interface IDllInitPolicy<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    Func<CancellationToken, Task> GetPolicy(IDllDefinition<TOwnership, TPlacement> init);
}
