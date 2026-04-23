using Microsoft.Data.Sqlite;

namespace FileCompositions.Core.Database.File.Resource.Db.Interface;

public interface IDbResourceInterface
{
     SqliteConnectionStringBuilder GetConnectionStringBuilder();
}
