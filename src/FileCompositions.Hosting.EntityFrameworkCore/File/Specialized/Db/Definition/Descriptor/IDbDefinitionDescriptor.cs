using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Descriptor;

internal interface IDbDefinitionDescriptor<TOwnership, TPlacement, TDbContext>
    : IFileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext;
