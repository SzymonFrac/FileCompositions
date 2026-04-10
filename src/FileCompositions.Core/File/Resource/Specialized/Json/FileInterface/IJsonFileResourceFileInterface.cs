using FileCompositions.Core.File.Resource.Specialized.FileInterface;

namespace FileCompositions.Core.File.Resource.Specialized.Json.FileInterface;

public interface IJsonFileResourceFileInterface<TData> : ISpecializedFileResourceFileInterface
{
    Task<TData?> Read(CancellationToken cancellationToken = default);
    Task Write(TData value, CancellationToken cancellationToken = default);
}
