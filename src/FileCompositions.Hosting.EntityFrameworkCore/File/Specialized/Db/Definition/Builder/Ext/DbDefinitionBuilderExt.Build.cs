using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Ext;

public static partial class DbDefinitionBuilderExt
{
    extension<TOwnership, TPlacement, TDbContext>(IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext> builder)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext
    {
        internal IDbDefinitionBuilder<StrictDefinition, TPlacement, TDbContext> Strict() =>
            builder.Create<StrictDefinition, TPlacement>();
        internal IDbDefinitionBuilder<ExternalDefinition, TPlacement, TDbContext> External() =>
            builder.Create<ExternalDefinition, TPlacement>();
    }
}
