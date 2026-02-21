using FileCompositions.Core.Setting.Store;

namespace FileCompositions.Core.Setting.Implementations;

internal class ResourceSetting<TValue>(TValue? @default, IResourceSettingStore<TValue> store) : IResourceSetting<TValue>
{
    public TValue? Default { get; } = @default;
    public IResourceSettingStore<TValue> Store { get; } = store;
}
