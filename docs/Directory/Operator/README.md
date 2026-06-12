<h1 align="center">
  Directory Operator
</h1>

<p align="center">
  <i>Carries out all directory operations</i>
</p>

## Basics

*File operations includes operations such as create, delete, exists, etc.*

### Type Definition

```csharp
public interface IDirectoryOperator<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
```

## Extension Methods

### IDirectoryOperator<StrictDefinition, RequiredDefinition>

*None*

---

### IDirectoryOperator<ExternalDefinition, RequiredDefinition>

*None*

---

### IDirectoryOperator<StrictDefinition, OptionalDefinition>

| Return Type       | Name                           | Description                     |
|-------------------|--------------------------------|---------------------------------|
| `ValueTask`       | CreateAsync(CancellationToken) | Creates the directory.          |
| `ValueTask`       | DeleteAsync(CancellationToken) | Deletes the directory.          |
| `ValueTask<bool>` | ExistsAsync(CancellationToken) | Checks if the directory exists. |

---

### IDirectoryOperator<ExternalDefinition, OptionalDefinition>

| Return Type       | Name                           | Description                     |
|-------------------|--------------------------------|---------------------------------|
| `ValueTask<bool>` | ExistsAsync(CancellationToken) | Checks if the directory exists. |

---
