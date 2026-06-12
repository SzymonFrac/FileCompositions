<h1 align="center">
  File Definition
</h1>

<p align="center">
  <i>Represents a file defined in the application</i>
</p>

## Basics

Every file definition has a [`FileDefinitionKey`](../Key) that must be distinct.

There is no implementation of a base `IFileDefinition`, since the library currently assumes that every file has an extension and is 'specialised'.

### Type Definition

```csharp
public interface IFileDefinition<TOwnership, TPlacement> : IFileInterface<TOwnership, TPlacement>,
    IFileInit<TOwnership, TPlacement>,
    IFileOperator<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
```

The file definition will inherit every component:
- [Interface](../Interface)
- [Init](../Init)
- [Operator](../Operator)
