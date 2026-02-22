# Settings
Settings are individual properties that are stored in any resource.
### Register
```csharp
public class MyJsonSettingsClass(string settingOne, int settingTwo, bool settingThree)
{
    public string SettingOne { get; set; } = settingOne;
    public int SettingTwo { get; set; } = settingTwo;
    public bool SettingThree { get; set; } = settingThree;
}

private static IHost CreateHost() => Host.CreateDefaultBuilder()
    .ConfigureFileResources(schema =>
    {
        schema.ConfigureResources((resources, ctx) =>
        {
            resources.Directories(dirs => dirs
                .Store(register => register
                    .UseKey(new DirectoryLocationKey(0))
                    .Register(config => config
                        .WithAddress(StorageAddress.Create("C:\\My\\Storage\\Directory")))));

            resources.Files(files => files
                .Store(register => register
                    .To(new DirectoryLocationKey(0))
                    .UseKey(new FileResourceKey("mySampleFile"))
                    .File(config => config
                        .WithName("sampleFile"))
                    .Register(mux => mux
                        .AsJson<MyJsonSettingsClass>(json => json
                            .UseSerializerOptions(new() { WriteIndented = true }),
                        // register a setting and bind it to a property in a json file
                        settings => settings
                            .RegisterSetting<string>(config => config
                                .To(new ResourceSettingKey("mySampleSetting"))
                                .BindTo(
                                    get: o => o?.SettingOne,
                                    set: (o, v) => o?.SettingOne = v
                                ))))));
        });
    }
```

### Call
```csharp
public MainWindowViewModel([FromKeyedServices("mySampleSetting")] IResourceSetting<string> sampleSetting) =>
    _sampleSetting = sampleSetting;
```

## Using settings to register directories
The main motivation for settings is to configure addresses (directories) during registration.
For example, a user sets a directory to export files, the app will then register the directory where the files should be on next load.
> [!NOTE]
> Currently, the library does not automatically detect changes during runtime. The changes would be applied when the app restarts (or a new host is run).
> This will be a feature in a future version.

### Defining settings in resource schema
> [!IMPORTANT]
> Currently, the schema only allows string type settings `IResourceSetting<string>` to be registered, which will resolve to a `StorageAddress`. This will be changed in a future version.

> [!CAUTION]
> Settings are resolved after each `.ConfigureResources` call. If you attempt to use a setting that is registered in the same block the value will always be default.
> This will also be improved. 
```csharp
.ConfigureFileResources(schema =>
{
    //Define a setting to use during registration. Constant paths are also allowed.
    schema.ConfigureRoots(roots => roots
        .Define("constant", StorageAddress.Create("C:\\My\\Constant\\Address")));
        .Define(config => config
            .WithKey(new("mySampleSetting"))
            .WithDefault("C:\\My\\Default\\Address"));

    schema.ConfigureResources((resources, ctx) =>
    {
        resources.Directories(dirs => dirs
            .Store(register => register
                .UseKey(new DirectoryLocationKey(0))
                .Register(config => config
                    .WithAddress(StorageAddress.Create("C:\\My\\Storage\\Directory")))));

        resources.Files(files => files
            .Store(register => register
                .To(new DirectoryLocationKey(0))
                .UseKey(new FileResourceKey("mySampleFile"))
                .File(config => config
                    .WithName("sampleFile"))
                .Register(mux => mux
                    .AsJson<MyJsonSettingsClass>(json => json
                        .UseSerializerOptions(new() { WriteIndented = true }),
                    // register a setting and bind it to a property in a json file
                    settings => settings
                        .RegisterSetting<string>(config => config
                            .To(new ResourceSettingKey("mySampleSetting"))
                            .BindTo(
                                get: o => o?.SettingOne,
                                set: (o, v) => o?.SettingOne = v
                            ))))));
    });

    // 'mySampleSetting' is now resolved
    schema.ConfigureResources((resources, ctx) =>
    {
        resources.Directories(dirs => dirs
            .Store(register => register
                .UseKey(new(1))
                .Register(config => config
                    .WithAddress(ctx.GetSetting(new("mySampleSetting"))))));
    });
})
```

A directory (and all files registered within) could also be [Optional](/docs/optional) rather than have a default value.
Although optional files exist in the library, they aren't yet fully functional with settings. This will be improved in a later version.
