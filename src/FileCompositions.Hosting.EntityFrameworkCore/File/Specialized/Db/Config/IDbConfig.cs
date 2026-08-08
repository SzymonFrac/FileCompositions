using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Descriptor;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Config;

public interface IDbConfig<TDbContext>
    where TDbContext : DbContext
{
    IDbConfig<TDbContext> WithName(string name);

    internal DbDefinitionDescriptor<TOwnership, TPlacement, TDbContext> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
}
