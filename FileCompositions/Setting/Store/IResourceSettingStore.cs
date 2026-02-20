namespace FileCompositions.Core.Setting.Store;

public interface IResourceSettingStore<TValue>
{
    Task<TValue?> ReadRaw();
    Task WriteRaw(TValue value);
}
