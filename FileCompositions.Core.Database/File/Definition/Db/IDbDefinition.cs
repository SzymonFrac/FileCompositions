using FileCompositions.Core.Database.File.Resource.Db;
using FileCompositions.Core.Database.File.Resource.Db.Builder;
using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.ResourceName;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db;

public interface IDbDefinition<TOwnership, TNecessity, TDbContext> : IFileDefinition<TOwnership, TNecessity>, IDbResource<TDbContext>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TDbContext : DbContext;

public interface IDbDefinition<TOwnership, TNecessity> : IFileDefinition<TOwnership, TNecessity>, IDbResource
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;

public interface IDbDefinition : IFileDefinition, IDbResource
{
    internal abstract static IDbResource Convert(IDirectoryLocation directory, StorageResourceName name, Action<IDbResourceBuilder>? config = default);
}
