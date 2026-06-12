<h1 align='center'>
  Local File System Location
</h1>

<p align='center'>
  <i>The location type used for local file paths</i>
</p>

## Brief

The `LocalFileSystemLocation` is used to address files on the local client.

### Type Definition

```csharp
public sealed record LocalFileSystemLocation(FileSystemAddress Address, FileSystemResourceName Name)
  : FileSystemLocation(Address, Name)
```
