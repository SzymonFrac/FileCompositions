using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Builder.Factory;

public interface IDbDefinitionBuilderFactory<TInOwnership, TInNecessity, TDbContext>
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
    where TDbContext : DbContext
{
    IDbDefinitionBuilder<TInOwnership, TInNecessity, TDbContext> Create();
    internal IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}

public interface IDbDefinitionBuilderFactory<TInOwnership, TInNecessity>
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
{
    IDbDefinitionBuilder<TInOwnership, TInNecessity> Create();
    internal IDbDefinitionBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
