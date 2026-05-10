using FileCompositions.Core.Database.File.Definition.Db.Extensions;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.Storage.ResourceName;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Resource.Db.Abstract;

internal abstract class DbResource<TDbContext>(IFileContext context, string name)
    : DbResource(context, name), IDbResource<TDbContext>
        where TDbContext : DbContext;

internal abstract class DbResource(IFileContext context, string name)
    : FileResource(context, StorageResourceName.CreateDb(name)), IDbResource
{
    public virtual SqliteConnectionStringBuilder GetConnectionStringBuilder() =>
        new()
        {
            DataSource = GetFullLocation().ToString()
        };
}
