<h1 align="center">
  Host Resource Schema
</h1>

<p align="center">
  <i>schema implementation using the IHost</i>
</p>

## Basics

The `IHostResourceSchema` registers file and directory definitions to the `Microsoft.Extensions.Hosting.IHost`.

`IHostResourceSchema` is part of the `.Core.Hosting` namespace.
Install `FileCompositions.Core.Hosting` to use the schema.

### Type Definition

```csharp
internal interface IHostResourceSchema : IResourceSchema
```

## Register Definitions

Use the `ConfigureFileComposition` extension method on the `IHostBuilder`
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

### Start the Host

> [!WARNING]
> If the host isn't started, the definitions won't initalise.
> This means that required files could be absent which will lead to errors.

Once you build the `IHost`, simply start the host at any entry-point of the application.

```csharp
var host = CreateHost();
await host.StartAsync();
```
