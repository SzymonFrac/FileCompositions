<h1 align="center">
  Json Definition
</h1>

<p align="center">
  <i>Represents a json file defined in the application</i>
</p>

## Basics

### Type Definition

```csharp
public interface IJsonDefinition<TOwnership, TPlacement, TData> : IFileDefinition<TOwnership, TPlacement>,
    IJsonInterface<TOwnership, TPlacement, TData>,
    IJsonInit<TOwnership, TPlacement, TData>,
    IJsonOperator<TOwnership, TPlacement, TData>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
```

*inherits [IFileDefinition](../../../Definition)*

The file definition will inherit every component:
- [Interface](../Interface)
- [Init](../Init)
- [Operator](../Operator)
