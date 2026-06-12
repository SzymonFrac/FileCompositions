<h1 align='center'>
  File System Address
</h1>

<p align='center'>
  <i>Represents the path of a directory in a file system.</i>
</p>

## Brief

Different file systems have different path conventions to its contents.

A local path could be `C:\Users\user\Downloads`, while a cloud path could be `https://...`.
Because of this, `StorageAddress` is abstract and can be implemented to follow conventions of some file system.

Currently, only the `LocalFileSystemAddress` is implemented.

| Name                                  | Used by                            | Brief                                   |
|---------------------------------------|------------------------------------|-----------------------------------------|
| [LocalFileSystemAddress](Type/Local/) | [`LocalFileSystem`](../Type/Local) | Storage address used for a local client |

### Type Definition

```csharp
public abstract record FileSystemAddress
```

---

> [!NOTE]
> The `FileSystemAddress` is intended to be implementable for a custom file system, but is not currently ready.
