using FileCompositions.Core.Database.File.Interface.Specialized.Db;
using FileCompositions.Core.Database.File.Operator.Specialized.Db;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Init;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db;

public interface IDbDefinition<TOwnership, TPlacement, TDbContext> : IFileDefinition<TOwnership, TPlacement>,
    IDbInterface<TOwnership, TPlacement>,
    IDbDefinitionInit<TOwnership, TPlacement, TDbContext>,
    IDbOperator<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext;
