using FileCompositions.Core.Database.File.Interface.Specialized.Db;
using FileCompositions.Core.Database.File.Resource.Db;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db;

public interface IDbDefinition<TOwnership, TPlacement, TDbContext> : IFileDefinition<TOwnership, TPlacement>, IDbFileInterface<TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext;

public interface IDbDefinition<TOwnership, TPlacement> : IFileDefinition<TOwnership, TPlacement>, IDbFileInterface<TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement;

internal interface IDbDefinition : IFileDefinition
{
    abstract static IDbResource Convert(in IFileContext context, string name);
}
