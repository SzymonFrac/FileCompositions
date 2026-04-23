using FileCompositions.Core.Database.File.Resource.Db.Context;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.Storage.ResourceName;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Resource.Db.Implementations;

internal class DbResource<TDbContext>(IDbResourceContext context, StorageResourceName name)
    : DbResource(context, name), IDbResource<TDbContext>
        where TDbContext : DbContext;

internal class DbResource(IDbResourceContext context, StorageResourceName name)
    : AbstractFileResource(context, name), IDbResource
{
    new public IDbResourceContext Context { get; } = context;

    public SqliteConnectionStringBuilder GetConnectionStringBuilder() =>
        new()
        {
            DataSource = GetFullLocation().ToString()
        };
}
