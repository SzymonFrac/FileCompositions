<h1 align="center">
  Db Interface
</h1>

## Basics

File compositions does not try to replace interacting with a database file using the interface.
The library only manages the file itself.
\
Accessing the database depends on the schema used.
For example, using the [`IHostResourceSchema`](../../../Schema/Types/Host) the database context should be accessed from the `IHost` service provider.
When [registering a db file with a database context](../../../Schema/Types/Host/EFCore), the context will also be registered to the `IHost`.

### Type Definition

```csharp
public interface IDbInterface<TOwnership, TPlacement> : IFileInterface<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
```

*inherits [`IFileInterface`](../../../Interface)*

## Extension Methods

### IDbInterface<StrictDefinition, RequiredInRequired>

| Return Type                     | Name                         | Description                                                                             |
|---------------------------------|------------------------------|-----------------------------------------------------------------------------------------|
| `SqliteConnectionStringBuilder` | GetConnectionStringBuilder() | Returns an `SqliteConnectionStringBuilder` with DataSource as the location of the file. |

---

### IDbInterface<ExternalDefinition, RequiredInRequired>

| Return Type                     | Name                         | Description                                                                             |
|---------------------------------|------------------------------|-----------------------------------------------------------------------------------------|
| `SqliteConnectionStringBuilder` | GetConnectionStringBuilder() | Returns an `SqliteConnectionStringBuilder` with DataSource as the location of the file. |

---

### IDbInterface<StrictDefinition, OptionalInRequired>

| Return Type                     | Name                         | Description                                                                             |
|---------------------------------|------------------------------|-----------------------------------------------------------------------------------------|
| `SqliteConnectionStringBuilder` | GetConnectionStringBuilder() | Returns an `SqliteConnectionStringBuilder` with DataSource as the location of the file. |

---

### IDbInterface<ExternalDefinition, OptionalInRequired>

| Return Type                     | Name                         | Description                                                                             |
|---------------------------------|------------------------------|-----------------------------------------------------------------------------------------|
| `SqliteConnectionStringBuilder` | GetConnectionStringBuilder() | Returns an `SqliteConnectionStringBuilder` with DataSource as the location of the file. |

---

### IDbInterface<StrictDefinition, OptionalInOptional>

| Return Type                     | Name                         | Description                                                                             |
|---------------------------------|------------------------------|-----------------------------------------------------------------------------------------|
| `SqliteConnectionStringBuilder` | GetConnectionStringBuilder() | Returns an `SqliteConnectionStringBuilder` with DataSource as the location of the file. |

---

### IDbInterface<ExternalDefinition, OptionalInOptional>

| Return Type                     | Name                         | Description                                                                             |
|---------------------------------|------------------------------|-----------------------------------------------------------------------------------------|
| `SqliteConnectionStringBuilder` | GetConnectionStringBuilder() | Returns an `SqliteConnectionStringBuilder` with DataSource as the location of the file. |

---
