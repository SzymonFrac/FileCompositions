<h1 align="center">
  Directory Definition
</h1>

## Basics

Every directory definition has a [`DirectoryDefinitionKey`](../Key) that must be distinct.

### Type Definition

```csharp
public interface IDirectoryDefinition<TOwnership, TNecessity> : IDirectoryInterface<TOwnership, TNecessity>,
    IDirectoryInit<TOwnership, TNecessity>,
    IDirectoryOperator<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
```

The directory definition will inherit every component:
- [Interface](../Interface)
- [Init](../Init)
- [Operator](../Operator)
