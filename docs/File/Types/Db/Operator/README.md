<h1 align="center">
  Db Operator
</h1>

## Basics

The db operator inherits its `Delete` and `Exists` from the base [`IFileOperator`](../../../Operator)

The db operator cannot `Create` the file currently, because there isn't a meaningful default db file.
Although, this could possibly change.

### Type Definition

```csharp
public interface IDbOperator<TOwnership, TPlacement> : IFileOperator<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
```
