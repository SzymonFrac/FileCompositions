using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Abstract;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Implementations;

internal sealed class DbDefinitionBuilder<TOwnership, TPlacement, TDbContext>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner, Action<IDbOptions<TDbContext>> config)
    : AbstractDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>(inner, config)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext;