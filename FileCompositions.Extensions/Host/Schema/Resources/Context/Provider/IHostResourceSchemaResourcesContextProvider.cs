using FileCompositions.Core.Setting.Descriptor;
using FileCompositions.Core.Setting.Key;
using FileCompositions.Core.Storage.Address;

namespace FileCompositions.Extensions.Host.Schema.Resources.Context.Provider;

public interface IHostResourceSchemaResourcesContextProvider
{
    StorageAddress GetSetting(ResourceSettingKey key);
    StorageAddress GetAddress(string addressName);
    void UpdateProvider(List<IResourceSettingDescriptor<string>> addedDescriptors, Dictionary<string, StorageAddress> addresses);
    void SetSettings(IServiceProvider sp);
}
