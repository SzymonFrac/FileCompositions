using FileCompositions.Core.Quality;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Quality.Ext;

public static partial class DbQualityExt
{
    extension<TOwnership, TPlacement, TDbContext>(IDbQuality<TOwnership, TPlacement, TDbContext> db)
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDbContext : DbContext
    {
        public SqliteConnectionStringBuilder GetConnectionStringBuilder() =>
            new()
            {
                DataSource = db.Addressing.Location.ToString()
            };
    }
}
