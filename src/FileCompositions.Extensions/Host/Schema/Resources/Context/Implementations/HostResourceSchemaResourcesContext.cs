using FileCompositions.Core.Setting;
using FileCompositions.Core.Setting.Key;
using FileCompositions.Core.Storage.Address;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Resources.Context.Implementations;

internal class HostResourceSchemaResourcesContext(IDictionary<string, StorageAddress> addresses) : IHostResourceSchemaResourcesContext
{
    private readonly IDictionary<string, StorageAddress> _addresses = addresses;

    public StorageAddress GetAddress(string addressName) => _addresses[addressName];
    public IResourceSetting<TValue> GetSetting<TValue>(in IServiceProvider sp, ResourceSettingKey key) =>
        sp.GetKeyedService<IResourceSetting<TValue>>(key.Value) ??
            throw new ArgumentException($"No setting is registered under key: {key}", nameof(key));
}
