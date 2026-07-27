using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Init.Policy;

internal interface IDllInitPolicy<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    Func<CancellationToken, ValueTask> GetPolicy(IDllDefinition<TOwnership, TPlacement> init);
}
