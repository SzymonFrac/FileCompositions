using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Options.Abstract;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Init.Policy.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options.Abstract;

internal abstract partial class AbstractDbOptions<TDbContext> : AbstractFileOptions<IDbOptions<TDbContext>>, IDbOptions<TDbContext>
    where TDbContext : DbContext
{
    public FileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement =>
            key => (in context) => new DbDefinition<TOwnership, TPlacement, TDbContext>(context, key, Name)
            {
                InitPolicy = new DefaultDbInitPolicy<TOwnership, TPlacement, TDbContext>()
            };
}
