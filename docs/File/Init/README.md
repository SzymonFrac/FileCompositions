<h1 align="center">
  File Init
</h1>

<p align="center">
  <i>Carries out initialisation of the file</i>
</p>

## Basics

Currently, initialisation will only run after registration.

### Type Definition

The base file init uses basic operators from the `IFileSystem`.

```csharp
public interface IFileInit<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
```

### General [Quality](../../Qualities) implications

#### StrictDefinition, RequiredInRequired

A file should be created on initialise if not present already.
There could be validation to check if the data in the file matches the format of the file, but this isn't implicit.

---

#### ExternalDefinition, RequiredInRequired

The file should already exist.
If the file does not exist there is an error on initialise.

---

#### StrictDefinition, OptionalInRequired

The file could check if the data matches the file type when it exists, but is not implicit.

---

#### ExternalDefinition, OptionalInRequired

No initialisation.

---

#### StrictDefinition, OptionalInOptional

The file could check if the data matches the file type when it exists, but is not implicit.

---

#### ExternalDefinition, OptionalInOptional

No initialisation.

---

### Specialized

Every file will initialise differently depending on what the file type is.
For more information check the [specific file](../Types)'s init.
