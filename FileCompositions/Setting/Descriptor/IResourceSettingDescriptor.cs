using FileCompositions.Core.Setting.Key;
using FileCompositions.Core.Setting.Store;

namespace FileCompositions.Core.Setting.Descriptor;

public interface IResourceSettingDescriptor<TValue>
{
    ResourceSettingKey Key { get; }
    TValue? Default { get; }
    TValue? Value { get; }
    void Activate(IResourceSettingStore<TValue> store);
}
