<h1 align="center">
  Json Init
</h1>

## Basics

The json will initialise on registration internally.

### Type Definition

```csharp
public interface IJsonInit<TOwnership, TPlacement, TData> : IFileInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
```

*inherits [`IFileInit`](../../../Init)*

