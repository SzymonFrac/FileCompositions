<h1 align='center'>
  File System Location
</h1>

<p align='center'>
  <i>Represents the path of a file in a file system.</i>
</p>

## Brief

Different file systems have different path conventions to its contents.

A local path could be `C:\Users\user\Downloads\download.mp4`, while a cloud path could be `https://...`.
Because of this, `StorageLocation` is abstract and can be implemented to follow conventions of some file system.

A location is composed of a [`FileSystemAddress`](../Address) and a [`FileSystemResourceName`](../ResourceName).
An address is used for the directory part, and the name is for the file name with an extension.
\
An implementation of a location is needed to combine them correctly depending on the file system it is used for.

Currently, only the `LocalFileSystemLocation` is implemented.

| Name                                   | Used by                            | Brief                                    |
|----------------------------------------|------------------------------------|------------------------------------------|
| [LocalFileSystemLocation](Type/Local/) | [`LocalFileSystem`](../Type/Local) | Storage location used for a local client |

### Type Definition

```csharp
public abstract record FileSystemLocation(FileSystemAddress Address, FileSystemResourceName Name);
```
