<h1 align='center'>
  Local File System Address
</h1>

<p align='center'>
  <i>The address type used for local directory paths</i>
</p>

## Brief

The `LocalFileSystemAddress` is used to address directories on the local client.

It is used with the [`LocalFileSystemLocation`](../../../Location/Type/Local) to address files in the file system.

### Type Definition

```csharp
public sealed record LocalFileSystemAddress : FileSystemAddress
```

## Behaviour

### Methods

| Return Type              | Name                                               | Description                                                                                |
|--------------------------|----------------------------------------------------|--------------------------------------------------------------------------------------------|
| `LocalFileSystemAddress` | Create(string)                                     | Creates a local address from the full string path                                          |
| `LocalFileSystemAddress` | Create(params ReadOnlySpan<string>)                | Creates a local address from the list of directory names                                   |
| `LocalFileSystemAddress` | Create(SpecialFolder)                              | Creates a local address from the `SpecialFolder` enum                                      |
| `LocalFileSystemAddress` | Create(SpecialFolder, params ReadOnlySpan<string>) | Creates a local address starting at the `SpecialFolder`, followed by the extra directories |
| `LocalFileSystemAddress` | Extend(params ReadOnlySpan<string>)                | Extend the current address to another directory path                                       |

