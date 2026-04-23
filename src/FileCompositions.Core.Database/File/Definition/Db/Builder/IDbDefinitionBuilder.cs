using FileCompositions.Core.Database.File.Resource.Db.Builder;
using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Builder;

public interface IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> : IDbDefinitionBuilder<TOwnership, TNecessity>, IDbResourceBuilder<TDbContext>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TDbContext : DbContext
{
    new IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> WithName(string name);
    new internal IDbDefinition<TOwnership, TNecessity, TDbContext> Build(IDirectoryLocation directory);
}

public interface IDbDefinitionBuilder<TOwnership, TNecessity> : IFileDefinitionBuilder<TOwnership, TNecessity>, IDbResourceBuilder
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    new IDbDefinitionBuilder<TOwnership, TNecessity> WithName(string name);
    new IDbDefinitionBuilder<TOwnership, TNecessity, TNewDbContext> AddDbContext<TNewDbContext>()
        where TNewDbContext : DbContext;
    new internal IDbDefinition<TOwnership, TNecessity> Build(IDirectoryLocation directory);
}
