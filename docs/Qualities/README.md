<h1 align="center">
  Qualities
</h1>

<p align="center">
  <i>In FileCompositions, a quality is an independent characteristic that determines what your definition can do and expose.</i>
</p>

## Basics

Currently, there are two qualities for both directory and file definitions, but there are three qualities in total.

| Quality                        | Directory | File | Brief                                                       |
|--------------------------------|-----------|------|-------------------------------------------------------------|
| [**Ownership**](Ownership.md) | ✅       | ✅   | Marks whether the definition is owned by the application.   |
| [**Necessity**](Necessity.md) | ✅       | ❌   | Marks whether the directory must exist in the file system.  |
| [**Placement**](Placement.md) | ❌       | ✅   | Marks whether the file must exist in the file system.       |

Qualities appear on definitions as generic parameters; some files may have extra generic parameters, so the qualities are always first.

> IDirectoryDefinition<TOwnership, TNecessity>

> IFileDefinition<TOwnership, TPlacement>

## Configure Qualities

When configuring, to modify a definition to be a different quality you simply need to write the name of the quality onto the builder.
Schema registrars will register definitions with the configured qualities.
By default, every definition is `Strict` and `Required`.

```csharp
// Using the IHostResourceSchema from .Hosting
static IHost CreateHost() => Host.CreateDefaultBuilder()
    .ConfigureFileComposition(schema =>
    {
        schema.ConfigureDefinitions(register =>
        {
            // Registers an Optional, External dll file in a Required, Strict directory.
            register
              .Store(config => config
                  .Define(dir => dir
                      .CreateLocal(Environment.SpecialFolder.Desktop, "MyDirectory")
                      .WithKey(new(0)))
                  .WithFiles(files => files
                      .DefineDll(dll => dll
                          .Create()
                          .Optional()
                          .External()
                          .WithKey(new(0))
                          .WithName("MyDll"))));
        });
    })
    .Build();
```

> [!IMPORTANT]
> If a directory is optional, the files must be optional too.
> 
> The schema builder will automatically set the default of the files to be optional.

<br>

Then from your DI container you get:

```csharp
var host = CreateHost();
await host.StartAsync();

using var scope = host.Services.CreateScope();

var directory = scope.ServiceProvider.GetRequiredKeyedService<IDirectoryDefinition<StrictDefinition, RequiredDefinition>>(new DirectoryDefinitionKey(0));
var file = scope.ServiceProvider.GetRequiredKeyedService<IDllDefinition<ExternalDefinition, OptionalInRequired>>(new FileDefinitionKey(0));
```

> [!IMPORTANT]
> Files also contain the Necessity of the parent directory.
> 
> This means that instead of an:
> 
> `IDllDefinition<ExternalDefinition, OptionalDefinition>`
> 
> you get:
> 
> `IDllDefinition<ExternalDefinition, OptionalInRequired>`
>
> Because the builder will implicitly know the Necessity of the directory the file is registered to.

## Usage

For full usage details, please check the specific [*quality*](#basics) documentation.

Some basic examples of how qualities change guarantees are:
- Optional files will provide a nullable result
- Some optional definitions will not need to be initialised
- Strict definitions have access to file operators such as Create.
- External definitions do not belong to the application.

## File Examples

A Strict, Required definition could be any configuration or data store, for example a database file.

A Strict, Optional definition could be a user preference that does not need to be set, but is managed by the application.

An External, Required definition is one that must exist but isn't managed by the application.
This type will likely not be common; however, this could be used for a roaming directory to ensure that there is no permission to delete.

An External, Optional definition could be a plugin file that does not need to be included.

---

### Notes

The Ownership and Necessity quality implementations end with 'Definition'.
Instead of 'Strict', there is `StrictDefinition`.
This is so that the library doesn't hold that general namespace/type.
Although, this could change to make definitions more brief/readable.
