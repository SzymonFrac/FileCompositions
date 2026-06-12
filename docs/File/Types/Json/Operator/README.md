<h1 align="center">
  Json Operator
</h1>

## Basics

The json operator inherits its `Delete` and `Exists` from the base [`IFileOperator`](../../../Operator)
The json operator implements `Create`, which creates a valid default file.

### Type Definition

```csharp
public interface IJsonOperator<TOwnership, TPlacement, TData> : IFileOperator<TOwnership, TPlacement>
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

| Return Type       | Name                           | Description                                |
|-------------------|--------------------------------|--------------------------------------------|
| `ValueTask`       | CreateAsync(CancellationToken) | Creates the json using it's default value. |

---

### IFileOperator<ExternalDefinition, OptionalInRequired>

*None*

---

### IFileOperator<StrictDefinition, OptionalInOptional>

| Return Type       | Name                              | Description                                                                                 |
|-------------------|-----------------------------------|---------------------------------------------------------------------------------------------|
| `ValueTask<bool>` | TryCreateAsync(CancellationToken) | Creates the json using it's default value, if the directory doesn't exist it returns false. |

---

### IFileOperator<ExternalDefinition, OptionalInOptional>

*None*

---
