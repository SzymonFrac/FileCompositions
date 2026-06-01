using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Descriptor;

internal interface IDbDefinitionDescriptor<TOwnership, TPlacement, TDbContext>
    : IFileDefinitionDescriptor<IDbDefinition<TOwnership, TPlacement, TDbContext>, TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext;
