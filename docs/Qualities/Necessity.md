<h1 align="center">
  Necessity - Quality
</h1>

<p align="center">
  <i>Marks whether the directory has to exist in the file system.</i>
  <br>
  <b>Necessity only applies to directories in a file system, not files</b>
</p>

## Basics

### Type Definition

```csharp
public abstract record DefinitionNecessity;
```

Currently, there are two types of necessity:

| Name     | Implementation Type  | Meaning                                        |
|----------|----------------------|------------------------------------------------|
| Required | `RequiredDefinition` | The directory always exists in the file system |
| Optional | `OptionalDefinition` | The directory may not exist in the file system |

### Behaviour

Depending on whether the directory must exist, the library will expose different functionallity.

When defining a required directory, the application will initialize/ensure.
This can depend on the [*Ownership*](Ownership.md) of the directory.
A strict, required directory will create; whereas, an external, required will throw an error if it doesn't exist.
\
An optional directory doesn't need to do anything by to initalize.

See more in [DirectoryInit](/../Directory/Init/README.md)

<br>

Directories can find non-defined files within themselves; although, no matter if the directory is optional or required, the implementation is the same since the file needs to be checked that it exists.

See more in [DirectoryInterface](/../Directory/Interface/README.md)

<br>

Required definitions must exist, so they don't have `Create` nor `Delete`.
Optional definitions will expose `Exists`, while required ones don't have to since it is always* true.

> [!NOTE]
> It is possible that a required definition could be manually deleted at runtime, or be corrupted.
> This could be something to work on in a future version.

See more in [DirectoryOperator](/../Directory/Operator/README.md)

---

*The full list of exposed functions can be seen on each individual section*
