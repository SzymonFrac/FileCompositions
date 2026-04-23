using FileCompositions.Core.File.Resource.Interface;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Interface;

public interface IJsonResourceInterface<TData> : IFileResourceInterface
{
    Task<TData?> Read(CancellationToken cancellationToken = default);
    Task Write(TData value, CancellationToken cancellationToken = default);
}
