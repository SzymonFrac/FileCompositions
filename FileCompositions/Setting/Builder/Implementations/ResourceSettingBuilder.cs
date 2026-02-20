using FileCompositions.Core.Setting.Descriptor;
using FileCompositions.Core.Setting.Descriptor.Implementations;
using FileCompositions.Core.Setting.Key;

namespace FileCompositions.Core.Setting.Builder.Implementations;

internal class ResourceSettingBuilder<TValue> : IResourceSettingBuilder<TValue>
{
    public ResourceSettingKey Key { get; private set; }
    public TValue? Default { get; private set; }


    public IResourceSettingBuilder<TValue> WithDefault(TValue? @default)
    {
        Default = @default;
        return this;
    }

    public IResourceSettingBuilder<TValue> WithKey(ResourceSettingKey key)
    {
        Key = key;
        return this;
    }

    public IResourceSettingDescriptor<TValue> Build() =>
        new ResourceSettingDescriptor<TValue>(Key, Default);
}
