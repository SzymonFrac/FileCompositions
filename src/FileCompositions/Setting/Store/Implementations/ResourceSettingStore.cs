namespace FileCompositions.Core.Setting.Store.Implementations;

internal class ResourceSettingStore<TValue>(
    Func<Task<TValue?>> read,
    Func<TValue, Task> write) : IResourceSettingStore<TValue>
{
    private readonly Func<Task<TValue?>> _read = read;
    private readonly Func<TValue, Task> _write = write;
    public Task<TValue?> ReadRaw() => _read();
    public Task WriteRaw(TValue value) => _write(value);
}
