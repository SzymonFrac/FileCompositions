# FileCompositions
[![NuGet](https://img.shields.io/nuget/v/FileCompositions.Core)](https://www.nuget.org/packages/FileCompositions.Core/)
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](LICENSE.txt)

## Installation
Via [NuGet](https://www.nuget.org/packages/FileCompositions.Core)
```sh
dotnet add package FileCompositions.Core
```

Currently [FileCompositions.Extensions](https://www.nuget.org/packages/FileCompositions.Extensions) is the only way of defining file resources using `IHost`
```sh
dotnet add package FileCompositions.Extensions
```

## Sample Usage
To get started, use the IHost extension to configure file resources.
```csharp
private static IHost CreateHost() => Host.CreateDefaultBuilder()
  .ConfigureFileResources(schema =>
  {
    ...
  })
  ...
  .Build()
```

### Compose Resources
> [!NOTE]
> Defining file resources does not implicitly create any resource. Each file must be [Ensured](/docs/validations/README.md).
> Storage addresses (directories) will be implicitly created unless marked as [Optional](/docs/optional/README.md)
```csharp
.ConfigureFileResources(schema =>
{
    // Resources includes Directories and Files
    schema.ConfigureResources((resources, ctx) =>
    {
        resources.Directories(dirs => dirs
            .Store(register => register
                .UseKey(new DirectoryLocationKey(0))
                .Register(config => config
                    .WithAddress(StorageAddress.Create("C:\\My\\Storage\\Directory"))))
            .Store(register => register
                .UseKey(new DirectoryLocationKey(1))
                .Register(config => config
                    .WithAddress(StorageAddress.Create("C:\\My\\Other\\Storage\\Directory")))));

        resources.Files(files => files
            .Store(register => register
                .To(new DirectoryLocationKey(0))
                .UseKey(new("mySampleJsonFile"))
                .File(config => config
                    .WithName("sampleJsonFile"))
                .Register(mux => mux
                    .AsJson<MyJsonSettings>(json => json
                        .UseSerializerOptions(new() { WriteIndented = true }))))
            .Store(register => register
                .To(new DirectoryLocationKey(1))
                .UseKey(new("mySampleDbFile"))
                .File(config => config
                    .WithName("sampleDbFile"))
                .Register(mux => mux.AsDb())));
    });
}
```

### Composition Options
File resources and directories have configurable options, which are shown in the [docs](/docs)

### Consume Resources
> [!IMPORTANT]
> A [database file](/docs/FileTypes/Db.md) is not intended to be consumed as a service. Instead, it defines a .db file to use when migrating in EFCore using Sqlite.
> You should inject your `AppDbContext` instead.
```csharp
public class MyConsumerClass
{
    private readonly IJsonFileResource<MyJsonSettings> _jsonFile;
    private readonly IDbFileResource _dbFileResource;

    public MyConsumerClass([FromKeyedServices("mySampleJsonFile")] IJsonFileResource<MyJsonSettings> jsonFile,
      [FromKeyedServices("mySampleDbFile")] IDbFileResource dbFileResource)
    {
        _jsonFile = jsonFile;
        _dbFileResource = dbFileResource;
    }
    public async Task<MyJsonSettings?> ReadSampleFile(CancellationToken cancellationToken = default) =>
        await _jsonFile.Read(cancellationToken);
}
```

#### [Currently supported file types](/docs/FileTypes)

## Roadmap & Features for future versions
- Unify all or as many standard file types under one library. Allow custom user-defined file types compatibility with composition.
- Create native storage backend implementations for major cloud providers.
- Allow composition beyond IHost.
- Allow resource schema to automatically assign ids for directories.
- Simplify and expand settings capabilities during composition time, to remove bloat syntax and allow for any setting type to be available.
- Native validations for all files with custom handlers.
- Extensions for functional programming, possibly using C# Language Extensions. Eg. allow `Option<T>` rather than `T?` for .json, .txt, .config etc.

If there are any features that should exist in the library to make it easier to integrate with real production code, please raise the issue.

## [License MIT](LICENSE.txt)
