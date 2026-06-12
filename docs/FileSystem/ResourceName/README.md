<h1 align="center">
  File System Resource Name
</h1>

<p align="center">
  <i>Represents a file name with its extension</i>
</p>

## Basics

A `FileSystemResourceName` comes after a [`FileSystemAddress`](../Address), it has a name and an extension.

### Type Definition

```csharp
public readonly record struct FileSystemResourceName
```

## Behaviour

### Properties

| Type                          | Name      | Description                                             |
|-------------------------------|-----------|---------------------------------------------------------|
| `string`                      | Value     | Name of the file only                                   |
| `FileSystemResourceExtension` | Extension | Extension of the file (including the leading period)    |

### Extension Methods

| Return Type              | Name               | Description                                                                       |
|--------------------------|--------------------|-----------------------------------------------------------------------------------|
| `FileSystemResourceName` | CreateJson(string) | Creates a `FileSystemResourceName` with a `.json` extension using the string name |
| `FileSystemResourceName` | CreateDll(string)  | Creates a `FileSystemResourceName` with a `.dll` extension using the string name  |
| `FileSystemResourceName` | CreateDb(string)   | Creates a `FileSystemResourceName` with a `.db` extension using the string name   |

