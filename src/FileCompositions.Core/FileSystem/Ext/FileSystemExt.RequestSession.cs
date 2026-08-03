using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.FileSystem.Request;
using FileCompositions.Core.FileSystem.Session;

namespace FileCompositions.Core.FileSystem.Ext;

public static partial class FileSystemExt
{
    extension(IFileSystem fileSystem)
    {
        internal Task RequestSessionAsync(FileSystemRequest request, FileSystemLocation location, CancellationToken cancellationToken = default)
        {
            using var session = new FileSystemSession(location, fileSystem);
            return request(session, cancellationToken);
        }

        internal Task<TResult> RequestSessionAsync<TResult>(FileSystemRequest<TResult> request, FileSystemLocation location, CancellationToken cancellationToken = default)
        {
            using var session = new FileSystemSession(location, fileSystem);
            return request(session, cancellationToken);
        }
    }
}
