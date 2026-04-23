using FileCompositions.Core.File.Resource.Interface;

namespace FileCompositions.Core.Setting.Store.Builder;

public interface IResourceSettingStoreBuilder<TValue, TFileInterface>
    where TFileInterface : IFileResourceInterface
{
    IResourceSettingStoreBuilder<TValue, TFileInterface> ReadRaw(Func<TFileInterface, Task<TValue?>> read);
    IResourceSettingStoreBuilder<TValue, TFileInterface> WriteRaw(Func<TFileInterface, TValue, Task> write);
    internal IResourceSettingStore<TValue> Build(TFileInterface fileInterface);
}
