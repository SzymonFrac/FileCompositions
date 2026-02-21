using FileCompositions.Core.Setting.Builder;
using FileCompositions.Core.Setting.Builder.Implementations;
using FileCompositions.Core.Setting.Descriptor;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Extensions.Host.Schema.Resources.Context.Provider;

namespace FileCompositions.Extensions.Host.Schema.Resources.Context.Builder.Implementations;

internal class HostResourceSchemaResourcesContextBuilder : IHostResourceSchemaResourcesContextBuilder
{
    private readonly Dictionary<string, StorageAddress> _addresses = [];
    private readonly List<IResourceSettingDescriptor<string>> _settingDescriptors = [];
    public IHostResourceSchemaResourcesContextBuilder Define(string name, StorageAddress address)
    {
        _addresses.Add(name, address);
        return this;
    }
    public IHostResourceSchemaResourcesContextBuilder Define(Action<IResourceSettingBuilder<string>> config)
    {
        var builder = new ResourceSettingBuilder<string>();
        config(builder);
        var descriptor = builder.Build();
        _settingDescriptors.Add(descriptor);

        return this;
    }

    public void UpdateProvider(ref IHostResourceSchemaResourcesContextProvider provider) =>
        provider.UpdateProvider(_settingDescriptors, _addresses);
}
