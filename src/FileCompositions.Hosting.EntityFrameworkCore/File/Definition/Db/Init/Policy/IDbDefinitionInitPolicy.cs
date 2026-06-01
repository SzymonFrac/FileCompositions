using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Init.Policy;

internal interface IDbDefinitionInitPolicy<TOwnership, TPlacement, TDbContext>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext
{
    Func<TDbContext, CancellationToken, ValueTask> GetPolicy(IDbDefinitionInit<TOwnership, TPlacement, TDbContext> init);
}
