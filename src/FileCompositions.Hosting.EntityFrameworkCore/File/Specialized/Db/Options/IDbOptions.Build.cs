using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;

public partial interface IDbOptions<TDbContext>
    where TDbContext : DbContext
{
    internal FileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>> Build<TOwnership, TPlacement>()
        where TOwnership : Ownership
        where TPlacement : Placement;
}
