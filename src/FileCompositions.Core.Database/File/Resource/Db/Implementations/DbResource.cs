using FileCompositions.Core.Database.File.Resource.Db.Abstract;
using FileCompositions.Core.File.Context;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Resource.Db.Implementations;

internal class DbResource<TDbContext>(IFileContext context, string name) : AbstractDbResource<TDbContext>(context, name)
    where TDbContext : DbContext;

internal class DbResource(IFileContext context, string name) : AbstractDbResource(context, name);
