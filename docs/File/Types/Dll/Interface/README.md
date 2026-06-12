<h1 align="center">
  Dll Interface
</h1>

## Basics

The dll interface doesn't allow writing currently (and possibly at all).
With a dll file you can run implementations of an interface in the application.
\
There could be more that a dll file could allow; this is mainly a proof of concept.

### Type Definition

```csharp
public interface IDllInterface<TOwnership, TPlacement> : IFileInterface<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
```

*inherits [`IFileInterface`](../../../Interface)*

## Extension Methods

### IDllInterface<StrictDefinition, RequiredInRequired>

| Return Type                  | Name                                                                                                     | Description                                                                            |
|------------------------------|----------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------|
| `Task<Assembly>`             | LoadAsync(CancellationToken)                                                                             | Loads and returns the assembly.                                                        |
| `IAsyncEnumerable<TResult>`  | RunEachAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>>, CancellationToken) | Run each instance of `TInterface` in the assembly returning a `TResult`, as a stream.  |
| `IAsyncEnumerable<TResult>`  | RunEachAsync<TInterface, TResult>(Func<TInterface, Task<TResult>>, CancellationToken)                    | Run each instance of `TInterface` in the assembly returning a `TResult`, as a stream.  |
| `Task<IEnumerable<TResult>>` | RunAllAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>>, CancellationToken)  | Run each instance of `TInterface` in the assembly returning a `TResult`, sequentially. |
| `Task<IEnumerable<TResult>>` | RunAllAsync<TInterface, TResult>(Func<TInterface, Task<TResult>>, CancellationToken)                     | Run each instance of `TInterface` in the assembly returning a `TResult`, sequentially. |
| `Task`                       | RunAsync<TInterface>(Func<TInterface, CancellationToken, Task>, CancellationToken)                       | Run each instance of `TInterface` in the assembly.                                     |
| `Task`                       | RunAsync<TInterface>(Func<TInterface, Task>, CancellationToken)                                          | Run each instance of `TInterface` in the assembly.                                     |
| `Task`                       | RunAsync<TInterface>(Action<TInterface>?, CancellationToken)                                             | Run each instance of `TInterface` in the assembly.                                     |


---

### IDllInterface<ExternalDefinition, RequiredInRequired>

| Return Type                  | Name                                                                                                     | Description                                                                            |
|------------------------------|----------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------|
| `Task<Assembly>`             | LoadAsync(CancellationToken)                                                                             | Loads and returns the assembly.                                                        |
| `IAsyncEnumerable<TResult>`  | RunEachAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>>, CancellationToken) | Run each instance of `TInterface` in the assembly returning a `TResult`, as a stream.  |
| `IAsyncEnumerable<TResult>`  | RunEachAsync<TInterface, TResult>(Func<TInterface, Task<TResult>>, CancellationToken)                    | Run each instance of `TInterface` in the assembly returning a `TResult`, as a stream.  |
| `Task<IEnumerable<TResult>>` | RunAllAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>>, CancellationToken)  | Run each instance of `TInterface` in the assembly returning a `TResult`, sequentially. |
| `Task<IEnumerable<TResult>>` | RunAllAsync<TInterface, TResult>(Func<TInterface, Task<TResult>>, CancellationToken)                     | Run each instance of `TInterface` in the assembly returning a `TResult`, sequentially. |
| `Task`                       | RunAsync<TInterface>(Func<TInterface, CancellationToken, Task>, CancellationToken)                       | Run each instance of `TInterface` in the assembly.                                     |
| `Task`                       | RunAsync<TInterface>(Func<TInterface, Task>, CancellationToken)                                          | Run each instance of `TInterface` in the assembly.                                     |
| `Task`                       | RunAsync<TInterface>(Action<TInterface>?, CancellationToken)                                             | Run each instance of `TInterface` in the assembly.                                     |

---

### IDllInterface<StrictDefinition, OptionalInRequired>

| Return Type                  | Name                                                                                                     | Description                                                                            |
|------------------------------|----------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------|
| `Task<Assembly?>`            | LoadAsync(CancellationToken)                                                                             | Loads and returns the assembly.                                                        |
| `IAsyncEnumerable<TResult>`  | RunEachAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>>, CancellationToken) | Run each instance of `TInterface` in the assembly returning a `TResult`, as a stream.  |
| `IAsyncEnumerable<TResult>`  | RunEachAsync<TInterface, TResult>(Func<TInterface, Task<TResult>>, CancellationToken)                    | Run each instance of `TInterface` in the assembly returning a `TResult`, as a stream.  |
| `Task<IEnumerable<TResult>>` | RunAllAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>>, CancellationToken)  | Run each instance of `TInterface` in the assembly returning a `TResult`, sequentially. |
| `Task<IEnumerable<TResult>>` | RunAllAsync<TInterface, TResult>(Func<TInterface, Task<TResult>>, CancellationToken)                     | Run each instance of `TInterface` in the assembly returning a `TResult`, sequentially. |
| `Task<bool>`                 | RunAsync<TInterface>(Func<TInterface, CancellationToken, Task>, CancellationToken)                       | Run each instance of `TInterface` in the assembly. Returns false when does not exist.  |
| `Task<bool>`                 | RunAsync<TInterface>(Func<TInterface, Task>, CancellationToken)                                          | Run each instance of `TInterface` in the assembly. Returns false when does not exist.  |
| `Task<bool>`                 | RunAsync<TInterface>(Action<TInterface>?, CancellationToken)                                             | Run each instance of `TInterface` in the assembly. Returns false when does not exist.  |

---

### IDllInterface<ExternalDefinition, OptionalInRequired>

| Return Type                  | Name                                                                                                     | Description                                                                            |
|------------------------------|----------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------|
| `Task<Assembly?>`            | LoadAsync(CancellationToken)                                                                             | Loads and returns the assembly.                                                        |
| `IAsyncEnumerable<TResult>`  | RunEachAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>>, CancellationToken) | Run each instance of `TInterface` in the assembly returning a `TResult`, as a stream.  |
| `IAsyncEnumerable<TResult>`  | RunEachAsync<TInterface, TResult>(Func<TInterface, Task<TResult>>, CancellationToken)                    | Run each instance of `TInterface` in the assembly returning a `TResult`, as a stream.  |
| `Task<IEnumerable<TResult>>` | RunAllAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>>, CancellationToken)  | Run each instance of `TInterface` in the assembly returning a `TResult`, sequentially. |
| `Task<IEnumerable<TResult>>` | RunAllAsync<TInterface, TResult>(Func<TInterface, Task<TResult>>, CancellationToken)                     | Run each instance of `TInterface` in the assembly returning a `TResult`, sequentially. |
| `Task<bool>`                 | RunAsync<TInterface>(Func<TInterface, CancellationToken, Task>, CancellationToken)                       | Run each instance of `TInterface` in the assembly. Returns false when does not exist.  |
| `Task<bool>`                 | RunAsync<TInterface>(Func<TInterface, Task>, CancellationToken)                                          | Run each instance of `TInterface` in the assembly. Returns false when does not exist.  |
| `Task<bool>`                 | RunAsync<TInterface>(Action<TInterface>?, CancellationToken)                                             | Run each instance of `TInterface` in the assembly. Returns false when does not exist.  |

---

### IDllInterface<StrictDefinition, OptionalInOptional>

| Return Type                  | Name                                                                                                     | Description                                                                            |
|------------------------------|----------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------|
| `Task<Assembly?>`            | LoadAsync(CancellationToken)                                                                             | Loads and returns the assembly.                                                        |
| `IAsyncEnumerable<TResult>`  | RunEachAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>>, CancellationToken) | Run each instance of `TInterface` in the assembly returning a `TResult`, as a stream.  |
| `IAsyncEnumerable<TResult>`  | RunEachAsync<TInterface, TResult>(Func<TInterface, Task<TResult>>, CancellationToken)                    | Run each instance of `TInterface` in the assembly returning a `TResult`, as a stream.  |
| `Task<IEnumerable<TResult>>` | RunAllAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>>, CancellationToken)  | Run each instance of `TInterface` in the assembly returning a `TResult`, sequentially. |
| `Task<IEnumerable<TResult>>` | RunAllAsync<TInterface, TResult>(Func<TInterface, Task<TResult>>, CancellationToken)                     | Run each instance of `TInterface` in the assembly returning a `TResult`, sequentially. |
| `Task<bool>`                 | RunAsync<TInterface>(Func<TInterface, CancellationToken, Task>, CancellationToken)                       | Run each instance of `TInterface` in the assembly. Returns false when does not exist.  |
| `Task<bool>`                 | RunAsync<TInterface>(Func<TInterface, Task>, CancellationToken)                                          | Run each instance of `TInterface` in the assembly. Returns false when does not exist.  |
| `Task<bool>`                 | RunAsync<TInterface>(Action<TInterface>?, CancellationToken)                                             | Run each instance of `TInterface` in the assembly. Returns false when does not exist.  |

---

### IDllInterface<ExternalDefinition, OptionalInOptional>

| Return Type                  | Name                                                                                                     | Description                                                                            |
|------------------------------|----------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------|
| `Task<Assembly?>`            | LoadAsync(CancellationToken)                                                                             | Loads and returns the assembly.                                                        |
| `IAsyncEnumerable<TResult>`  | RunEachAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>>, CancellationToken) | Run each instance of `TInterface` in the assembly returning a `TResult`, as a stream.  |
| `IAsyncEnumerable<TResult>`  | RunEachAsync<TInterface, TResult>(Func<TInterface, Task<TResult>>, CancellationToken)                    | Run each instance of `TInterface` in the assembly returning a `TResult`, as a stream.  |
| `Task<IEnumerable<TResult>>` | RunAllAsync<TInterface, TResult>(Func<TInterface, CancellationToken, Task<TResult>>, CancellationToken)  | Run each instance of `TInterface` in the assembly returning a `TResult`, sequentially. |
| `Task<IEnumerable<TResult>>` | RunAllAsync<TInterface, TResult>(Func<TInterface, Task<TResult>>, CancellationToken)                     | Run each instance of `TInterface` in the assembly returning a `TResult`, sequentially. |
| `Task<bool>`                 | RunAsync<TInterface>(Func<TInterface, CancellationToken, Task>, CancellationToken)                       | Run each instance of `TInterface` in the assembly. Returns false when does not exist.  |
| `Task<bool>`                 | RunAsync<TInterface>(Func<TInterface, Task>, CancellationToken)                                          | Run each instance of `TInterface` in the assembly. Returns false when does not exist.  |
| `Task<bool>`                 | RunAsync<TInterface>(Action<TInterface>?, CancellationToken)                                             | Run each instance of `TInterface` in the assembly. Returns false when does not exist.  |

---
