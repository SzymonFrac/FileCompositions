using FileCompositions.Core.Setting.Key;
using FileCompositions.Core.Setting.Store;

namespace FileCompositions.Core.Setting.Descriptor.Implementations;

internal class ResourceSettingDescriptor<TValue>(ResourceSettingKey key, TValue? @default) : IResourceSettingDescriptor<TValue>
{
    public ResourceSettingKey Key { get; } = key;
    public TValue? Default { get; } = @default;

    private TValue? value = @default;
    public TValue? Value => value;

    public async void Activate(IResourceSettingStore<TValue> store) =>
        value = store.ReadRaw().Result;
}
