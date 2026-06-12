<h1 align="center">
  Directory Interface
</h1>

<p align="center">
  <i>Used to search files in the directory</i>
</p>

## Basics

### Type Definition

```csharp
public interface IDirectoryInterface<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
```

### Behaviour

The directory interface is currently used to search for files in the directory.
The result will be an [`IFileResource`](../../File/Resource), of the specialised type that is searched for.

## Extension Methods

*Every type has the same extension methods for all [qualities](../../Qualities).*
\
*string names do not include the extension of the file.*

| Return Type                   | Name                                                   | Description                               | Namespace        |
|-------------------------------|--------------------------------------------------------|-------------------------------------------|------------------|
| `Task<IJsonResource<TData>?>` | GetJsonResourceAsync<TData>(string, CancellationToken) | Finds the json file with the string name. | `.Core`          |
| `Task<IDllResource?>`         | GetDllResourceAsync(string, CancellationToken)         | Finds the dll file with the string name.  | `.Core`          |
| `Task<IDbResource?>`          | GetDbResourceAsync(string, CancellationToken)          | Finds the db file with the string name.   | `.Core.Database` |

---

> [!NOTE]
> The directory interface should not need to depend on any qualities.
> This means that in a future version the interface could be non-generic.
