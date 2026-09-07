using FileCompositions.Core.Quality;
using Microsoft.Data.Sqlite;

namespace FileCompositions.Core.Database.File.Specialized.Db.Quality.Ext;

public static partial class DbQualityExt
{
    extension<TOwnership, TPlacement>(IDbQuality<TOwnership, TPlacement> db)
        where TOwnership : Ownership
        where TPlacement : Placement
    {
        public SqliteConnectionStringBuilder GetConnectionStringBuilder() =>
            new()
            {
                DataSource = db.Addressing.Location.ToString()
            };
    }
}
