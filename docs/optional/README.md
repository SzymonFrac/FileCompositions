# Optional Resources
Addresses (directories) can be made optional with `.Optional()`.
```csharp
resources.Directories(dirs => dirs
    .Store(register => register
        .UseKey(new DirectoryLocationKey(0))
        .Register(config => config
            .WithAddress(StorageAddress.Create("C:\\My\\Storage\\Directory"))
            .Optional())));
```

Currently, `.Optional()` simply does not create the address; by default any registered address is automatically created to ensure that file resources can be created within them.
This feature needs to be developed further to support:
- Optional file resources
- Reactive addresses and file resources. That is to create the optional resource when the necessary data or settings are in place during runtime.
- Validate when resource is ready to create rather than on composition.
