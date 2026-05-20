using FileCompositions.Core.Database.File.Definition.Db.Descriptor;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Builder;

public interface IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> : IFileDefinitionBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TDbContext : DbContext
{
    IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> WithKey(FileDefinitionKey key);
    IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> WithName(string name);

    IDbDefinitionBuilder<ExternalDefinition, TNecessity, TDbContext> External();
    IDbDefinitionBuilder<StrictDefinition, TNecessity, TDbContext> Strict();
    IDbDefinitionBuilder<TOwnership, RequiredDefinition, TDbContext> Required();
    IDbDefinitionBuilder<TOwnership, OptionalDefinition, TDbContext> Optional();

    internal IDbDefinition<TOwnership, TPlacement, TDbContext> Build<TPlacement>(in IFileContext context)
        where TPlacement : DefinitionPlacement;
    internal IDbDefinitionDescriptor<TOwnership, TPlacement, TDbContext> BuildDescriptor<TPlacement>()
        where TPlacement : DefinitionPlacement;
}

public interface IDbDefinitionBuilder<TOwnership, TNecessity> : IFileDefinitionBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    IDbDefinitionBuilder<TOwnership, TNecessity> WithKey(FileDefinitionKey key);
    IDbDefinitionBuilder<TOwnership, TNecessity> WithName(string name);

    IDbDefinitionBuilder<ExternalDefinition, TNecessity> External();
    IDbDefinitionBuilder<StrictDefinition, TNecessity> Strict();
    IDbDefinitionBuilder<TOwnership, RequiredDefinition> Required();
    IDbDefinitionBuilder<TOwnership, OptionalDefinition> Optional();

    internal IDbDefinition<TOwnership, TPlacement> Build<TPlacement>(in IFileContext context)
        where TPlacement : DefinitionPlacement;
    internal IDbDefinitionDescriptor<TOwnership, TPlacement> BuildDescriptor<TPlacement>()
        where TPlacement : DefinitionPlacement;
}
