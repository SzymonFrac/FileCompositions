using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Descriptor;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Builder;

public interface IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> : IFileDefinitionBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TDbContext : DbContext
{
    IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> WithKey(FileDefinitionKey key);
    IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> WithName(string name);
    IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> AutoMigrate(bool auto = true);

    IDbDefinitionBuilder<ExternalDefinition, TNecessity, TDbContext> External();
    IDbDefinitionBuilder<StrictDefinition, TNecessity, TDbContext> Strict();
    IDbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext> Required();
    IDbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext> Optional();

    internal IDbDefinition<TOwnership, TPlacement, TDbContext> Build<TPlacement>(in IFileContext context)
        where TPlacement : DefinitionPlacement;
    internal IDbDefinitionDescriptor<TOwnership, TPlacement, TDbContext> BuildDescriptor<TPlacement>()
        where TPlacement : DefinitionPlacement;
}
