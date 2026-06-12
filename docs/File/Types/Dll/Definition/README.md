<h1 align="center">
  Dll Definition
</h1>

<p align="center">
  <i>Represents a dll file defined in the application</i>
</p>

## Basics

### Type Definition

```csharp
public interface IDllDefinition<TOwnership, TPlacement> : IFileDefinition<TOwnership, TPlacement>,
    IDllInterface<TOwnership, TPlacement>,
    IDllInit<TOwnership, TPlacement>,
    IDllOperator<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
```

*inherits [IFileDefinition](../../../Definition)*

The file definition will inherit every component:
- [Interface](../Interface)
- [Init](../Init)
- [Operator](../Operator)
