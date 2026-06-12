<h1 align="center">
  File System
</h1>

<p align="center">
  <i>Represents where directories and files live.</i>
</p>

## Basics

### Type definition

```csharp
public interface IFileSystem
```

File systems can be implemented using the `IFileSystem` interface.

Currently, there is only one implementation of a file system.

| Name  | Implementation Type  | Meaning                                        |
|-------|----------------------|------------------------------------------------|
| Local | `LocalFileSystem`    | The current device's file system               |

<br>

File systems represent any store of directories and files, which could include private servers and major cloud providers.

### Connecting File Systems to Definitions

Using the `IDirectoryDefinitionBuilderFactory`, create a builder to some file system.
`CreateLocal` will configure the builder to the `LocalFileSystem`.
\
Each method will take a [`FileSystemAddress`](Address/README.md) specialised to the file system.

```csharp
.Define((IDirectoryDefinitionBuilderFactory dir) => dir
  .CreateLocal(Environment.SpecialFolder.Desktop, "MyDirectory")
  .WithKey(new(0)))
```

### Registering other File Systems to a Schema

Every [`ResourceSchema`](../Schema) will include a configuration to register an implementation of a file system.

```csharp
// Using the .Hosting IHostResourceSchema
static IHost CreateHost() => Host.CreateDefaultBuilder()
    .ConfigureFileComposition(schema =>
    {
        schema.ConfigureFileSystems(fileSystems => fileSystems
            .Register<MyCloudFileSystem>());

        schema.ConfigureDefinitions(register =>
        {
            //...
        });
    })
    .Build();
```

The `IDirectoryDefinitionBuilderFactory` also has a `CreateDefault` function that accepts a file system generic.

```csharp
.Define((IDirectoryDefinitionBuilderFactory dir) => dir
  .CreateDefault<MyCloudFileSystem>(...)
  .WithKey(new(0)))
```

> [!IMPORTANT]
> The `CreateDefault` function takes an abstract `FileSystemAddress`.
> This means that an implementation of `IFileSystem` should also include its own address type.
> This is because different file systems have different directory and file paths.
>
> See more in [`StorageAddress`](Address/README.md)

---

> [!NOTE]
> Implementing file systems has not been fully worked on yet.
> It should be possible, but currently not recomended.
