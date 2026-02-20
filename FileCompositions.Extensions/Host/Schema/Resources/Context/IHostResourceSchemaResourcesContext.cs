using FileCompositions.Core.Setting;
using FileCompositions.Core.Setting.Key;
using FileCompositions.Core.Storage.Address;

namespace FileCompositions.Extensions.Host.Schema.Resources.Context;

public interface IHostResourceSchemaResourcesContext
{
    IResourceSetting<TValue> GetSetting<TValue>(in IServiceProvider sp, ResourceSettingKey key);
    StorageAddress GetAddress(string addressName);
}
