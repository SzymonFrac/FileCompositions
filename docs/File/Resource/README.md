<h1 align="center">
  File Resource
</h1>

<p align="center">
  <i>An External, Required undefined file</i>
</p>

## Brief

A file resource is an external, required file that is not used for registration, so does not have a key.
File resources are used by directory definition's [`interface`](../../Directory/Interface) to scan it's content for a file with the name.

### Type Definition

```csharp
public interface IFileResource : IFileInterface<ExternalDefinition, RequiredInRequired>,
    IFileInit<ExternalDefinition, RequiredInRequired>,
    IFileOperator<ExternalDefinition, RequiredInRequired>
```
