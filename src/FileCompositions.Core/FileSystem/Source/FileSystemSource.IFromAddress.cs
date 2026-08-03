using FileCompositions.Core.FileSystem.Request;

namespace FileCompositions.Core.FileSystem.Source;

public static partial class FileSystemSource
{
    public interface IFromAddress
    {
        internal ValueTask RequestFileSystemAsync(FileSystemRequest.Address request, CancellationToken cancellationToken = default);
        internal ValueTask<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest.Address<TResult> request, CancellationToken cancellationToken = default);
    }
}
