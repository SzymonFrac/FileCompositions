<h1 align="center">
  Directory Init
</h1>

<p align="center">
  <i>Carries out initialisation of the directory</i>
</p>

## Basics

Currently, initialisation will only run after registration.

### Type Definition

```csharp
public interface IDirectoryInit<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
```

### Behaviour

#### StrictDefinition, RequiredDefinition

The directory is created if it does not already exist in the file system.

---

#### ExternalDefinition, RequiredDefinition

The directory must already exist in the file system.
If it does not exist, the initialisation throws an error.

---

#### StrictDefinition, OptionalDefinition

No initialisation.

---

#### ExternalDefinition, OptionalDefinition

No initialisation.

---
