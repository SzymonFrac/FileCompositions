using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Ext;

public static partial class DbDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        public IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext> Db<TDbContext>(Action<IDbOptions<TDbContext>> config)
            where TDbContext : DbContext =>
                new DbDefinitionBuilder<TOwnership, TPlacement, TDbContext>(inner, config);
    }
}
