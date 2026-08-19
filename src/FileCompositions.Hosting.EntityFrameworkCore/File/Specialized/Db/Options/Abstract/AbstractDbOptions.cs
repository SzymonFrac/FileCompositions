using FileCompositions.Core.File.Options.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options.Abstract;

internal abstract partial class AbstractDbOptions<TDbContext> : AbstractFileOptions<IDbOptions<TDbContext>>, IDbOptions<TDbContext>
    where TDbContext : DbContext
{
    protected override IDbOptions<TDbContext> This() => this;
}
