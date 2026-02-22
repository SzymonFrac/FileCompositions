# Json File Resource
### Call
```csharp
public MyConsumerClass([FromKeyedServices("key")] IJsonFileResource<T> jsonFile) =>
    _jsonFile = jsonFile;
```

### File Interface
```csharp
public Task<MyJsonSettings?> ReadSampleFile(CancellationToken cancellationToken = default) =>
    _jsonFile.Read(cancellationToken);
public Task WriteSampleFile(MyJsonSettings data, CancellationToken cancellationToken = default) =>
    _jsonFile.Write(data, cancellationToken);
```
