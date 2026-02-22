# Db File Resource
### Call
> [!NOTE]
> Use a registered db file resource to configure the connection string in `.ConfigureServices()`.
> The db file resource is not meant to be a replacement for interacting with the database, rather a way to define where the file is stored when using SQlite.
> The migration of the database is still the app's responsibility - although this could possibly change if it were a beneficial feature.
```csharp
private static IHost CreateHost() => Host.CreateDefaultBuilder()
  .ConfigureFileResources(schema => ...)
  .ConfigureServices((context, services) =>
  {
      ...
      services.AddDbContext<AppDbContext>((sp, options) =>
      {
          var dbFile = sp.GetRequiredKeyedService<IDbFileResource>("key");
          options.UseSqlite(dbFile.GetConnectionString());
      });
  })
  ...
```

### File Interface
```csharp
public string GetConnectionString() => _dbFileResource.GetConnectionString();
```
