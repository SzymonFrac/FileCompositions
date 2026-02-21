using FileCompositions.Core.FileResource.Specialized.FileInterface;

namespace FileCompositions.Core.Setting.Store.Builder;

public interface IResourceSettingStoreBuilder<TValue, TFileInterface>
    where TFileInterface : ISpecializedFileResourceFileInterface
{
    IResourceSettingStoreBuilder<TValue, TFileInterface> ReadRaw(Func<TFileInterface, Task<TValue?>> read);
    IResourceSettingStoreBuilder<TValue, TFileInterface> WriteRaw(Func<TFileInterface, TValue, Task> write);
    internal IResourceSettingStore<TValue> Build(TFileInterface fileInterface);
}
