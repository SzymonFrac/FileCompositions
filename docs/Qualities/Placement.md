<h1 align="center">
  Placement - Quality
</h1>

<p align="center">
  <i>Marks whether the file has to exist in the file system.</i>
  <br>
  <b>Placement only applies to files in a file system, not directories</b>
</p>

## Basics

Placement is used for files, because the necessity of the directory further determines what the file can guarantee.
Importantly, placement also explicitly ensures that a required file cannot exist in an optional file.

### Type Definition

```csharp
public abstract record DefinitionPlacement;
```

Currently, there are three types of placement:

| Name                 | Implementation Type  | Meaning                                                                   |
|----------------------|----------------------|---------------------------------------------------------------------------|
| Required in Required | `RequiredInRequired` | The definition always exists in the file system                           |
| Optional in Required | `OptionalInRequired` | The definition may not exist in the file system, but the directory exists |
| Optional in Optional | `OptionalInOptional` | The definition may not exist in the file system, nor does the directory   |

> [!IMPORTANT]
> There is no Required in Optional because if a file always exists in the file system, then the directory must always exist.
> Even if the directory could be marked as optional, the file would make the directory effectivley required.

### Behaviour

Depending on whether the definition must exist, the library will expose different functionallity.

When defining a required definition, the application will initialize/ensure the definition.
This can depend on the [*Ownership*](Ownership.md) of the definition.
A strict, required definition will create with a default (if applicable); whereas, an external, required will throw an error if it doesn't exist.
\
An optional definition doesn't need to do anything by default to initalize.
Although there can be some initialization for optional definitions.
For example, an optional json file could be configured to ensure that its data can be parsed correctly.
This can be done to make sure that the file can be read correctly.

See more in [FileInit](../File/Init)

<br>

Writing and reading data from a required file will always have some data (including null).
The return types on specific types of files will reflect that, i.e., json will expose `Task<TData>` rather than `Task<JsonReadResult<TData>>`.
\
Optional definitions will also expose `Exists`, while required ones don't have to since it is always* true.

> [!NOTE]
> It is possible that a required definition could be manually deleted at runtime, or be corrupted.
> This could be something to work on in a future version.

See more in [FileInterface](../File/Interface)

<br>

Required definitions must exist, so they don't have `Create` nor `Delete`.
Each specialised file type operator will create files in such a way that will produce a valid file.
That is, a json file will serialize the default value and write; if the file was created with no data, then reading the file would result in an error.
For a dll file, this would be creating an empty assembly, etc.
\
*This is also implicitly done since there wouldn't be a good reason to use `Create`*.
Delete is the same for any file.

See more in [FileOperator](../File/Operator)

---

*The full list of exposed functions can be seen on each individual section*
