using FileCompositions.Core.File.Resource.Specialized.FileInterface;
using FileCompositions.Core.Setting.Store.Implementations;

namespace FileCompositions.Core.Setting.Store.Builder.Implementation;

internal class ResourceSettingStoreBuilder<TValue, TFileInterface> : IResourceSettingStoreBuilder<TValue, TFileInterface>
    where TFileInterface : ISpecializedFileResourceFileInterface
{
    private Func<TFileInterface, Task<TValue?>>? read;
    private Func<TFileInterface, TValue, Task>? write;
    public IResourceSettingStoreBuilder<TValue, TFileInterface> ReadRaw(Func<TFileInterface, Task<TValue?>> r)
    {
        read = r;
        return this;
    }

    public IResourceSettingStoreBuilder<TValue, TFileInterface> WriteRaw(Func<TFileInterface, TValue, Task> w)
    {
        write = w;
        return this;
    }

    public IResourceSettingStore<TValue> Build(TFileInterface fileInterface)
    {
        if (read is null)
            throw new ArgumentNullException(nameof(read));
        if (write is null)
            throw new ArgumentNullException(nameof(write));

        return new ResourceSettingStore<TValue>(
            () => read(fileInterface),
            v => write(fileInterface, v));
    }
}
