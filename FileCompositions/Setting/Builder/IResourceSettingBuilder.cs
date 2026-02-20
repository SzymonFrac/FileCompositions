using FileCompositions.Core.Setting.Descriptor;
using FileCompositions.Core.Setting.Key;

namespace FileCompositions.Core.Setting.Builder;

public interface IResourceSettingBuilder<TValue>
{
    IResourceSettingBuilder<TValue> WithKey(ResourceSettingKey key);
    IResourceSettingBuilder<TValue> WithDefault(TValue? @default);
    IResourceSettingDescriptor<TValue> Build();
}
