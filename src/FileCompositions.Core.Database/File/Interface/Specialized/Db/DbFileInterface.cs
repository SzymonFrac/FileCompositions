using FileCompositions.Core.File.Interface;
using FileCompositions.Core.Quality.Placement.Implementations;
using Microsoft.Data.Sqlite;

namespace FileCompositions.Core.Database.File.Interface.Specialized.Db;

public static class DbFileInterface
{
    extension(IDbFileInterface<RequiredInRequired> db)
    {
        public SqliteConnectionStringBuilder GetConnectionStringBuilder() =>
            new()
            {
                DataSource = db.GetLocation().ToString()
            };
    }

    extension(IDbFileInterface<OptionalInRequired> db)
    {
        public SqliteConnectionStringBuilder GetConnectionStringBuilder() =>
            new()
            {
                DataSource = db.GetLocation().ToString()
            };
    }

    extension(IDbFileInterface<OptionalInOptional> db)
    {
        public SqliteConnectionStringBuilder GetConnectionStringBuilder() =>
            new()
            {
                DataSource = db.GetLocation().ToString()
            };
    }
}
