using FileCompositions.Core.Setting.Store;

namespace FileCompositions.Core.Setting;

public interface IResourceSetting<TValue>
{
    TValue? Default { get; }
    IResourceSettingStore<TValue> Store { get; }
}
