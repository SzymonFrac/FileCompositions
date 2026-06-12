<h1 align="center">
  Resource Schema
</h1>

<p align='center'>
  <i>Used to register definitions to the application</i>
</p>

## Basics

A Resource Schema in file composition is used to orchiestrate the registration of definitions.
The Resource Schema doesn't necessarily contain definitions - it is not strictly a container.

There is currently only one implementation of a schema, which uses the `IHost` from `Microsoft.Extensions.Hosting`

| Schema                          | Brief                                                                                      |
|---------------------------------|--------------------------------------------------------------------------------------------|
| [HostResourceSchema](Type/Host) | The schema implementation that uses the `Microsoft.Extensions.Hosting.IHost` as a DI container | 

### Type Definition

```csharp
internal interface IResourceSchema
```

