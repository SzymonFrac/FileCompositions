using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Init.Policy;

internal interface IDbInitPolicy<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    Func<CancellationToken, Task> GetPolicy(IDbDefinition<TOwnership, TPlacement> init);
}
