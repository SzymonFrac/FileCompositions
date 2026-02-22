# Validations
Validations ensure the state of a file resource once all resources are configured. Validation reports the state; a handler responds to the state.

> [!NOTE]
> Currently, only json files have validation which only includes `.Ensure`.
> Db files do not have `.Ensure` since that is implicitly done by migrations, which is the app's responsibility in this version.
```csharp
public class MyJsonSettingsClass(string settingOne, int settingTwo, bool settingThree)
{
    public string SettingOne { get; set; } = settingOne;
    public int SettingTwo { get; set; } = settingTwo;
    public bool SettingThree { get; set; } = settingThree;
}
...

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
                        // Ensure a file exists, and use default values if absent
                        .WithValidation(validate => validate
                            .Ensure(handler => handler
                                .DefaultOnFail(new("default", 0, false))))))));
    })
})
```

The handler can also run any code depending if the validation passed or failed.
```csharp
.AsJson<MyJsonSettingsClass>(json => json
    .WithValidation(validate => validate
        .Ensure(handler => handler
            .OnFail(async fileResource =>
            {
                Debug.WriteLine($"{fileResource.Name} has failed!");
            })
            .OnOk(async fileResource =>
            {
                Debug.WriteLine($"{fileResource.Name} has passed!");
            }))));
```
