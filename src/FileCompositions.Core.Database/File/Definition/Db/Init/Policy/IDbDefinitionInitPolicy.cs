using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Definition.Db.Init.Policy;

internal interface IDbDefinitionInitPolicy<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    Func<CancellationToken, ValueTask> GetPolicy(IDbDefinitionInit<TOwnership, TPlacement> init);
}
