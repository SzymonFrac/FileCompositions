using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder;

public interface IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>
    : IFileDefinitionBuilder<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>, IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext
{
    internal IDbDefinitionBuilder<TNewOwnership, TNewPlacement, TDbContext> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : DefinitionOwnership
        where TNewPlacement : DefinitionPlacement;
}
