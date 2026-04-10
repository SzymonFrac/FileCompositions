using FileCompositions.Core.File.Resource.Specialized.Json.FileInterface;
using FileCompositions.Core.Setting.Implementations;
using FileCompositions.Core.Setting.Key;
using FileCompositions.Core.Setting.Store;
using FileCompositions.Core.Setting.Store.Builder;
using FileCompositions.Core.Setting.Store.Builder.Implementation;

namespace FileCompositions.Core.Setting.Builder.To.Json.Implementations;

internal class ResourceSettingBuilderToJson<TValue, TData> : IResourceSettingBuilderToJson<TValue, TData>
{
    private TValue? @default;
    private IResourceSettingStoreBuilder<TValue, IJsonFileResourceFileInterface<TData>>? storeBuilder;

    public ResourceSettingKey Key { get; private set; }

    public IResourceSettingBuilderToJson<TValue, TData> To(ResourceSettingKey key)
    {
        Key = key;
        return this;
    }
    public IResourceSettingBuilderToJson<TValue, TData> WithDefault(TValue? d)
    {
        @default = d;
        return this;
    }
    public IResourceSettingBuilderToJson<TValue, TData> UsingSettingStore(Action<IResourceSettingStoreBuilder<TValue, IJsonFileResourceFileInterface<TData>>> config)
    {
        var builder = new ResourceSettingStoreBuilder<TValue, IJsonFileResourceFileInterface<TData>>();
        config(builder);
        storeBuilder = builder;
        return this;
    }
    public IResourceSettingBuilderToJson<TValue, TData> BindTo(Func<TData?, TValue?> get, Action<TData?, TValue> set)
    {
        var builder = new ResourceSettingStoreBuilder<TValue, IJsonFileResourceFileInterface<TData>>()
            .ReadRaw(async i => get(await i.Read()))
            .WriteRaw(async (i, v) =>
            {
                var data = await i.Read();
                set(data, v);
                if (data is null) return;

                await i.Write(data);
            });

        storeBuilder = builder;
        return this;
    }
    public IResourceSettingBuilderToJson<TValue, TData> BindToImmutable(Func<TData?, TValue?> get, Func<TData?, TValue, TData> set)
    {
        var builder = new ResourceSettingStoreBuilder<TValue, IJsonFileResourceFileInterface<TData>>()
            .ReadRaw(async i => get(await i.Read()))
            .WriteRaw(async (i, v) =>
            {
                var data = await i.Read();
                var newData = set(data, v);
                await i.Write(newData);
            });

        storeBuilder = builder;
        return this;
    }

    public IResourceSetting<TValue> Build(IJsonFileResourceFileInterface<TData> fileInterface)
    {
        if (storeBuilder is null)
            throw new ArgumentNullException(nameof(storeBuilder));

        var store = storeBuilder.Build(fileInterface);
        var setting = new ResourceSetting<TValue>(@default, store);
        return setting;
    }

}
