using FileCompositions.Core.File.Addressing.Ext;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.Data.Sqlite;

namespace FileCompositions.Core.Database.File.Specialized.Db.Quality.Ext;

public static partial class DbQualityExt
{
    extension<TOwnership, TPlacement>(IDbQuality<TOwnership, TPlacement> db)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        public SqliteConnectionStringBuilder GetConnectionStringBuilder() =>
            new()
            {
                DataSource = db.RequestLocation().ToString()
            };
    }
}
