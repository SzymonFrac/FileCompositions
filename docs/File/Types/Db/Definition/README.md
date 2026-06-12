<h1 align="center">
  Db Definition
</h1>

<p align="center">
  <i>Represents a db file defined in the application</i>
</p>

## Basics

### Type Definition

```csharp
public interface IDbDefinition<TOwnership, TPlacement> : IFileDefinition<TOwnership, TPlacement>,
    IDbInterface<TOwnership, TPlacement>,
    IDbInit<TOwnership, TPlacement>,
    IDbOperator<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement

public interface IDbDefinition<TOwnership, TPlacement, TDbContext> : IFileDefinition<TOwnership, TPlacement>,
    IDbInterface<TOwnership, TPlacement>,
    IDbInit<TOwnership, TPlacement, TDbContext>,
    IDbOperator<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext
```

*inherits [IFileDefinition](../../../Definition)*

The file definition will inherit every component:
- [Interface](../Interface)
- [Init](../Init)
- [Operator](../Operator)
