using FileCompositions.Core.FileResource.Specialized.FileInterface;

namespace FileCompositions.Core.FileResource.Specialized.Json.FileInterface;

public interface IJsonFileResourceFileInterface<TData> : ISpecializedFileResourceFileInterface
{
    Task<TData?> Read(CancellationToken cancellationToken = default);
    Task Write(TData value, CancellationToken cancellationToken = default);
}
