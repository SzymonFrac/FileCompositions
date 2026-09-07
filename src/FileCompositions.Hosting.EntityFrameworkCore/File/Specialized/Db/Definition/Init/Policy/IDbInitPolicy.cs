using FileCompositions.Core.Quality;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Init.Policy;

internal interface IDbInitPolicy<TOwnership, TPlacement, TDbContext>
    where TOwnership : Ownership
    where TPlacement : Placement
    where TDbContext : DbContext
{
    Func<TDbContext, CancellationToken, Task> GetPolicy(IDbDefinition<TOwnership, TPlacement, TDbContext> init);
}
