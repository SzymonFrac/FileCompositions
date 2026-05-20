using FileCompositions.Core.Database.File.Definition.Db.Extensions;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.Storage.Resource.Name;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Resource.Db.Abstract;

internal abstract class AbstractDbResource<TDbContext>(IFileContext context, string name)
    : AbstractDbResource(context, name), IDbResource<TDbContext>
        where TDbContext : DbContext;

internal abstract class AbstractDbResource(IFileContext context, string name)
    : FileResource(context, StorageResourceName.CreateDb(name)), IDbResource;
