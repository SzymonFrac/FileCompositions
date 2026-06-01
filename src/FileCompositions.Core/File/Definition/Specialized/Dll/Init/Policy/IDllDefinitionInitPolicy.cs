using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Init.Policy;

internal interface IDllDefinitionInitPolicy<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    Func<CancellationToken, ValueTask> GetPolicy(IDllDefinitionInit<TOwnership, TPlacement> init);
}
