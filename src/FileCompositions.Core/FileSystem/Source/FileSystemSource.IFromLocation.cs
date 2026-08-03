using FileCompositions.Core.FileSystem.Request;

namespace FileCompositions.Core.FileSystem.Source;

public static partial class FileSystemSource
{
    public interface IFromLocation
    {
        internal Task RequestFileSystemAsync(FileSystemRequest.Location request, CancellationToken cancellationToken = default);
        internal Task<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest.Location<TResult> request, CancellationToken cancellationToken = default);
    }
}
