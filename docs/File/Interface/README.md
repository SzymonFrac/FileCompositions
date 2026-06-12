<h1 align="center">
  File Interface
</h1>

<p align="center">
  <i>Carries out all file data work</i>
</p>

## Basics

### Type Definition

The base file interface has operations using streams from the `IFileSystem`.

```csharp
public interface IFileInterface<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
```

## Specialised

Different file types will have different operations, since there are different things that can be done with each file's data.
For example, json can be read/write but a dll can be run/load.
\
For more information check the [specific file](../Types)'s interface.
