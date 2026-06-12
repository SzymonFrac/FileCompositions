<h1 align="center">
  Dll Init
</h1>

## Basics

The dll will initialise on registration internally.

### Type Definition

```csharp
public interface IDllInit<TOwnership, TPlacement> : IFileInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement;
```

*inherits [`IFileInit`](../../../Init)*
