<h1 align="center">
  Dll Operator
</h1>

## Basics

The dll operator inherits its `Delete` and `Exists` from the base [`IFileOperator`](../../../Operator)
The dll operator implements `Create`, which creates a valid default file.

A default for a dll in FileCompositions is an empty assembly called 'Default'.

### Type Definition

```csharp
public interface IDllOperator<TOwnership, TPlacement> : IFileOperator<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
```

## Extension Methods

### IDllOperator<StrictDefinition, RequiredInRequired>

*None*

---

### IDllOperator<ExternalDefinition, RequiredInRequired>

*None*

---

### IDllOperator<StrictDefinition, OptionalInRequired>

| Return Type       | Name                           | Description                                |
|-------------------|--------------------------------|--------------------------------------------|
| `ValueTask`       | CreateAsync(CancellationToken) | Creates the dll using a default assembly.  |

---

### IDllOperator<ExternalDefinition, OptionalInRequired>

*None*

---

### IDllOperator<StrictDefinition, OptionalInOptional>

| Return Type       | Name                              | Description                                                                                 |
|-------------------|-----------------------------------|---------------------------------------------------------------------------------------------|
| `ValueTask<bool>` | TryCreateAsync(CancellationToken) | Creates the dll using a default assembly, if the directory doesn't exist it returns false.  |

---

### IDllOperator<ExternalDefinition, OptionalInOptional>

*None*

---
