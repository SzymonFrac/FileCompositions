<h1 align="center">
  Ownership - Quality
</h1>

<p align="center">
  <i>Marks whether the definition is owned by the application.</i>
</p>

## Basics

### Type Definition

```csharp
public abstract record DefinitionOwnership;
```

Currently, there are two types of ownership:

| Name     | Implementation Type  | Meaning                                        |
|----------|----------------------|------------------------------------------------|
| Strict   | `StrictDefinition`   | The definition is owned by the application     |
| External | `ExternalDefinition` | The definition is not owned by the application |

### Behaviour

Strict definitions have control over their lifecycle.
They can perform file or directory operations, such as Create or Delete.
Although, this can depend on the [*Necessity*](Necessity.md) or [*Placement*](Placement.md) of the definition.

For example, a required definition cannot be deleted because that would break its guarantee.
Similarly, there is no need to create the definition if it is required, so there is no exposed `Create` method.

See more in [FileOperator](../File/Operator)

<br>

Also, writing to a strict file can create the file whereas an external file cannot.
For strict files it is assumed to create the file if it doesn't exist.

See more in [FileInterface](../File/Interface)

<br>

External definitions don't have any initialisation, unless it is required.
An external, required definition can throw an exception; this type must be present in the file system without initialization.

See more in [FileInit](../File/Init)

---

*The full list of exposed functions can be seen on each individual section*
