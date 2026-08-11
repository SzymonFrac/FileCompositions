using FileCompositions.Core.File.Options;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;

public partial interface IDbOptions<TDbContext> : IFileOptions<IDbOptions<TDbContext>>
    where TDbContext : DbContext;
