using FileCompositions.Core.Database.File.Definition.Db.Builder.Implementations;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Builder.Factory.Implementations;

internal class DbDefinitionBuilderFactory<TInOwnership, TInNecessity, TDbContext>(DirectoryDefinitionKey key) : IDbDefinitionBuilderFactory<TInOwnership, TInNecessity, TDbContext>
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
    where TDbContext : DbContext
{
    private readonly DirectoryDefinitionKey _key = key;

    public IDbDefinitionBuilder<TInOwnership, TInNecessity, TDbContext> Create() =>
        new DbDefinitionBuilder<TInOwnership, TInNecessity, TDbContext>(_key);

    public IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity =>
            new DbDefinitionBuilder<TOwnership, TNecessity, TDbContext>(_key);
}

internal class DbDefinitionBuilderFactory<TInOwnership, TInNecessity>(DirectoryDefinitionKey key) : IDbDefinitionBuilderFactory<TInOwnership, TInNecessity>
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
{
    private readonly DirectoryDefinitionKey _key = key;

    public IDbDefinitionBuilder<TInOwnership, TInNecessity> Create() =>
        new DbDefinitionBuilder<TInOwnership, TInNecessity>(_key);

    public IDbDefinitionBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity =>
            new DbDefinitionBuilder<TOwnership, TNecessity>(_key);
}

