<h1 align="center">
  Json Interface
</h1>

## Basics

### Type Definition

```csharp
public interface IJsonInterface<TOwnership, TPlacement, TData> : IFileInterface<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
```

*inherits [`IFileInterface`](../../../Interface)*

## Extension Methods

### IJsonInterface<StrictDefinition, RequiredInRequired, TData>

| Return Type    | Name                                 | Description                    |
|----------------|--------------------------------------|--------------------------------|
| `Task<TData?>` | ReadAsync(CancellationToken)         | Reads and serialises the data. |
| `Task`         | WriteAsync(TData, CancellationToken) | Writes the data provided.      |

---

### IJsonInterface<ExternalDefinition, RequiredInRequired, TData>

| Return Type    | Name                                 | Description                    |
|----------------|--------------------------------------|--------------------------------|
| `Task<TData?>` | ReadAsync(CancellationToken)         | Reads and serialises the data. |
| `Task`         | WriteAsync(TData, CancellationToken) | Writes the data provided.      |

---

### IJsonInterface<StrictDefinition, OptionalInRequired, TData>

| Return Type                   | Name                                 | Description                                                   |
|-------------------------------|--------------------------------------|---------------------------------------------------------------|
| `Task<TData?>`                | ReadAsync(CancellationToken)         | Reads and serialises the data.                                |
| `Task<JsonReadResult<TData>>` | ReadResultAsync(CancellationToken)   | Reads the data, and returns a [`JsonReadResult`](ReadResult). |
| `Task`                        | WriteAsync(TData, CancellationToken) | Writes the data provided.                                     |

---

### IJsonInterface<ExternalDefinition, OptionalInRequired, TData>

| Return Type                   | Name                                 | Description                                                   |
|-------------------------------|--------------------------------------|---------------------------------------------------------------|
| `Task<TData?>`                | ReadAsync(CancellationToken)         | Reads and serialises the data.                                |
| `Task<JsonReadResult<TData>>` | ReadResultAsync(CancellationToken)   | Reads the data, and returns a [`JsonReadResult`](ReadResult). | 
| `Task<bool>`                  | WriteAsync(TData, CancellationToken) | Writes the data provided, and returns the success.            |

---

### IJsonInterface<StrictDefinition, OptionalInOptional, TData>

| Return Type                   | Name                                 | Description                                                   |
|-------------------------------|--------------------------------------|---------------------------------------------------------------|
| `Task<TData?>`                | ReadAsync(CancellationToken)         | Reads and serialises the data.                                |
| `Task<JsonReadResult<TData>>` | ReadResultAsync(CancellationToken)   | Reads the data, and returns a [`JsonReadResult`](ReadResult). | 
| `Task<bool>`                  | WriteAsync(TData, CancellationToken) | Writes the data provided, and returns the success.            |

---

### IJsonInterface<ExternalDefinition, OptionalInOptional, TData>

| Return Type                   | Name                                 | Description                                                   |
|-------------------------------|--------------------------------------|---------------------------------------------------------------|
| `Task<TData?>`                | ReadAsync(CancellationToken)         | Reads and serialises the data.                                |
| `Task<JsonReadResult<TData>>` | ReadResultAsync(CancellationToken)   | Reads the data, and returns a [`JsonReadResult`](ReadResult). | 
| `Task<bool>`                  | WriteAsync(TData, CancellationToken) | Writes the data provided, and returns the success.            |

---

