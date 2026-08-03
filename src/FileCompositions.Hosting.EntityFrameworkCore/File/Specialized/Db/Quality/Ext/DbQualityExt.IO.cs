using FileCompositions.Core.File.Addressing.Ext;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Quality.Ext;

public static partial class DbQualityExt
{
    extension<TOwnership, TPlacement, TDbContext>(IDbQuality<TOwnership, TPlacement, TDbContext> db)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext
    {
        public SqliteConnectionStringBuilder GetConnectionStringBuilder() =>
            new()
            {
                DataSource = db.RequestLocation().ToString()
            };
    }
}
