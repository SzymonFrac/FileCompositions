using FileCompositions.Core.FileSystem.Request;
using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.FileSystem;

public partial interface IFileSystem
{
    internal sealed IFileSystemSource RequestSource() => new Source(this);

    private sealed class Source(in IFileSystem fileSystem) : IFileSystemSource
    {
        private readonly IFileSystem _fileSystem = fileSystem;

        public Task RequestAsync(FileSystemRequest request, CancellationToken cancellationToken) => request(_fileSystem, cancellationToken);
        public Task<TResult> RequestAsync<TResult>(FileSystemRequest<TResult> request, CancellationToken cancellationToken) => request(_fileSystem, cancellationToken);
    }
}
