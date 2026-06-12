<h1 align="center">
  File Operator
</h1>

<p align="center">
  <i>Carries out all file operations</i>
</p>

## Basics

*File operations includes operations such as create, delete, exists, etc.*

### Type Definition

The base file operator uses basic operators from the `IFileSystem`.

```csharp
public interface IFileOperator<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
```

## Extension Methods

### IFileOperator<StrictDefinition, RequiredInRequired>

*None*

---

### IFileOperator<ExternalDefinition, RequiredInRequired>

*None*

---

### IFileOperator<StrictDefinition, OptionalInRequired>

| Return Type       | Name                           | Description                |
|-------------------|--------------------------------|----------------------------|
| `ValueTask`       | DeleteAsync(CancellationToken) | Deletes the file.          |
| `ValueTask<bool>` | ExistsAsync(CancellationToken) | Checks if the file exists. |

---

### IFileOperator<ExternalDefinition, OptionalInRequired>

| Return Type       | Name                           | Description                |
|-------------------|--------------------------------|----------------------------|
| `ValueTask<bool>` | ExistsAsync(CancellationToken) | Checks if the file exists. |

---

### IFileOperator<StrictDefinition, OptionalInOptional>

| Return Type       | Name                           | Description                |
|-------------------|--------------------------------|----------------------------|
| `ValueTask`       | DeleteAsync(CancellationToken) | Deletes the file.          |
| `ValueTask<bool>` | ExistsAsync(CancellationToken) | Checks if the file exists. |

---

### IFileOperator<ExternalDefinition, OptionalInOptional>

| Return Type       | Name                           | Description                |
|-------------------|--------------------------------|----------------------------|
| `ValueTask<bool>` | ExistsAsync(CancellationToken) | Checks if the file exists. |

---

## Specialised

There is no public Create function on the base `IFileOperator`, this is because even though the base operator can create an empty file, the file is not necessarily usable.
Each file type operator will expose a public create method, which creates a valid file.

> [!NOTE]
> This implies that a required file is one that is also usable, rather than just 'must exist'.

For more information check the [specific file](../Types)'s operator.

