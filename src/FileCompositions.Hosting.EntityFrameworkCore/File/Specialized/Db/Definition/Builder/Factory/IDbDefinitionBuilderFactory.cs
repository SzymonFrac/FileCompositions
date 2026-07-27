using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Factory;

public interface IDbDefinitionBuilderFactory<TInNecessity>
    where TInNecessity : DefinitionNecessity
{
    internal DirectoryDefinitionKey Key { get; }

    IDbDefinitionBuilder<StrictDefinition, TInNecessity, TDbContext> Create<TDbContext>()
        where TDbContext : DbContext;
    internal IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> Create<TOwnership, TNecessity, TDbContext>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDbContext : DbContext;
}
