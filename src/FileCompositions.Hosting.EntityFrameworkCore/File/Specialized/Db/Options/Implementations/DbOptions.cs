using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options.Implementations;

internal sealed class DbOptions<TDbContext> : AbstractDbOptions<TDbContext>
    where TDbContext : DbContext;
