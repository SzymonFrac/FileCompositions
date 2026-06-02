using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.Data.Sqlite;

namespace FileCompositions.Core.Database.File.Interface.Specialized.Db;

public static class DbInterface
{
    extension<TOwnership, TPlacement>(IDbInterface<TOwnership, TPlacement> db)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        public SqliteConnectionStringBuilder GetConnectionStringBuilder() =>
            new()
            {
                DataSource = db.GetLocation().ToString()
            };
    }
}
