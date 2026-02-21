using FileCompositions.Core.Setting;
using FileCompositions.Core.Setting.Descriptor;
using FileCompositions.Core.Setting.Key;
using FileCompositions.Core.Storage.Address;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Resources.Context.Provider.Implementations;

internal class HostResourceSchemaResourcesContextProvider(IDictionary<string, StorageAddress> addresses,
    ref List<IResourceSettingDescriptor<string>> settingDescriptors) : IHostResourceSchemaResourcesContextProvider
{
    private readonly IDictionary<string, StorageAddress> _addresses = addresses;
    internal List<IResourceSettingDescriptor<string>> _settingDescriptors = settingDescriptors;

    public StorageAddress GetAddress(string addressName) => _addresses[addressName];
    public StorageAddress GetSetting(ResourceSettingKey key) => StorageAddress.Create(_settingDescriptors.First(d => d.Key == key).Value ?? "");

    public void SetSettings(IServiceProvider sp)
    {
        if (_settingDescriptors.Count != 0)
            foreach (var descriptor in _settingDescriptors)
            {
                var setting = sp.GetKeyedService<IResourceSetting<string>>(descriptor.Key.Value);
                if (setting is null)
                    continue;
                descriptor.Activate(setting.Store);
            }
    }

    public void UpdateProvider(List<IResourceSettingDescriptor<string>> addedDescriptors, Dictionary<string, StorageAddress> addresses)
    {
        foreach (var item in addedDescriptors)
            _settingDescriptors.Add(item);
        foreach (var item in addresses)
            _addresses.Add(item);
    }
}
