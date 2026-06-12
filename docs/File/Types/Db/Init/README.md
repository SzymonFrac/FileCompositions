<h1 align="center">
  Db Init
</h1>

## Basics

The db will initialise on registration internally.

`FileCompositions.Hosting.EntityFrameworkCore` provides the `TDbContext` overload.
When the `TDbContext` is known, the file can be initialised at the location by migrating.

Otherwise, without a `TDbContext` the file is created empty (if required).
Since the [interface](../Interface) does not read anything, there isn't any risk of an error.

### Type Definition

```csharp
public interface IDbInit<TOwnership, TPlacement> : IFileInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement

public interface IDbInit<TOwnership, TPlacement, TDbContext> : IFileInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext
```

*inherits [`IFileInit`](../../../Init)*
