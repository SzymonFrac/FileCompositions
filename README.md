<h1 align="center">
  FileCompositions
</h1>

<p align="center">
  <a href="https://www.nuget.org/packages/FileCompositions.Core/"><img src="https://img.shields.io/nuget/v/FileCompositions.Core"></a>
  <a href="LICENSE.txt"><img src="https://img.shields.io/github/license/mashape/apistatus.svg"></a>
</p>

<p align="center">
  FileCompositions is a C# library that allows a program to define files and directories as resources in DI from many file systems.
</p>

![Demo](assets/FileCompositionsDemo.gif)

## Requirements
Targets
`.NET 10.0`

## Installation
Via [NuGet](https://www.nuget.org/packages/FileCompositions.Core)
```sh
dotnet add package FileCompositions.Core
```

Currently [FileCompositions.Hosting](https://www.nuget.org/packages/FileCompositions.Hosting) is the only way of defining file resources using `IHost`
```sh
dotnet add package FileCompositions.Hosting
```

## Getting Started
To get started, use the IHost extension to configure file resources.
```csharp
private static IHost CreateHost() => Host.CreateDefaultBuilder()
  .ConfigureFileComposition(schema =>
  {
    ...
  })
  ...
  .Build()
```

### Add Definitions
To add any files, you first must define a directory.

```csharp
// Todo:
// Define a Requied and Strict json file of type MyApplicationData, with name "myConfiguration"
// in 'Roaming/MyFunApp' directory.

static IHost CreateHost() => Host.CreateDefaultBuilder()
    .ConfigureFileComposition(schema =>
    {
        schema.ConfigureDefinitions(registrar => registrar
            .Store(directory =>
            {
                directory.Define(def => def
                    .CreateLocal(Environment.SpecialFolder.ApplicationData,
                        "MyFunApp")
                    .WithKey(new DirectoryDefinitionKey(0)));

                directory.WithFiles(files => files
                    .DefineJson(json => json
                        .Create<MyApplicationData>()
                        .WithName("myConfiguration")
                        .WithKey(new FileDefinitionKey(0))));

                return directory;
            }));
    })
    .Build();
```

> [!Note]
> Initially, every definition is `Required` and `Strict` unless configured otherwise.
> Find out more about [`Qualities`](/docs/Qualities)

### Use your Definitions
Finally, use your definitions like any other DI service.

```csharp
public class MyConsumerClass
{
    private readonly IJsonDefinition<StrictDefinition, RequiredInRequired, MyApplicationData> _jsonFile;

    public MyConsumerClass([FromKeyedServices(0)] IJsonDefinition<StrictDefinition, RequiredInRequired, MyApplicationData> jsonFile)
    {
        _jsonFile = jsonFile;
    }
    public async Task<MyApplicationData> ReadSampleFile(CancellationToken cancellationToken = default) =>
        await _jsonFile.ReadAsync(cancellationToken);
}
```

#### [Currently supported file types](/docs/FileTypes)

## Roadmap & Features for future versions
- Unify all or as many standard file types under one library. Allow custom user-defined file types compatibility with composition.
- Create native storage backend implementations for major cloud providers.
- Allow composition beyond IHost.
- Include validations for different file types, which will give the app greater control over its files.
- Allow Optional (and Required) files/directories to depend on data from other files. Eg. to store a definition's file path.

If there are any features that should exist in the library to make it easier to integrate with real production code, please raise the issue.

## [License MIT](LICENSE.txt)
