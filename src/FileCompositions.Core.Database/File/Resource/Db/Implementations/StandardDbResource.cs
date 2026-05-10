using FileCompositions.Core.Database.File.Resource.Db.Abstract;
using FileCompositions.Core.File.Context;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Resource.Db.Implementations;

internal class StandardDbResource<TDbContext>(IFileContext context, string name) : DbResource<TDbContext>(context, name)
    where TDbContext : DbContext;

internal class StandardDbResource(IFileContext context, string name) : DbResource(context, name);
