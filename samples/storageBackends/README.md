# Storage Backends
Storage backends can be implemented using the `IStorageBackend` interface. Storage backends represent any store of directories and files, including private servers and major cloud providers.
A `OneDriveStorageBackend` could be created, and applied to any directory. An implementation could look like [this](storageBackends/OneDriveStorageBackend.cs)

### Connecting Backends to Addresses
> [!NOTE]
> Only addresses (directories) depend on the backend, resources (files) registered to an address will automatically connect to the address.
```csharp
private static IHost CreateHost() => Host.CreateDefaultBuilder()
    .ConfigureFileResources(schema =>
    {
        schema.ConfigureStorageBackends(backends =>
        {
            backends.Register<OneDriveStorageBackend>();
        });

        schema.ConfigureResources((resources, ctx) =>
        {
            resources.Directories(dirs => dirs
                .Store(register => register
                    .UseKey(new DirectoryLocationKey(0))
                    .Register(config => config
                        .WithAddress(StorageAddress.Create("C:\\My\\OneDrive\\Storage\\Directory"))
                        .ToStorageBackend<OneDriveStorageBackend>()));

            resources.Files(files => ...);
        })
    }
```
