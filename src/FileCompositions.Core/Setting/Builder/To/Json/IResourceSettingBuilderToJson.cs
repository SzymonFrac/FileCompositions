using FileCompositions.Core.File.Resource.Specialized.Json.Interface;
using FileCompositions.Core.Setting.Key;
using FileCompositions.Core.Setting.Store;
using FileCompositions.Core.Setting.Store.Builder;

namespace FileCompositions.Core.Setting.Builder.To.Json;

public interface IResourceSettingBuilderToJson<TValue, TData>
{
    IResourceSettingBuilderToJson<TValue, TData> BindTo(Func<TData?, TValue?> get, Action<TData?, TValue> set);
    IResourceSettingBuilderToJson<TValue, TData> BindToImmutable(Func<TData?, TValue?> get, Func<TData?, TValue, TData> set);
    IResourceSettingBuilderToJson<TValue, TData> To(ResourceSettingKey key);
    IResourceSettingBuilderToJson<TValue, TData> UsingSettingStore(Action<IResourceSettingStoreBuilder<TValue, IJsonResourceInterface<TData>>> config);
    internal IResourceSetting<TValue> Build(IJsonResourceInterface<TData> fileInterface);
}
