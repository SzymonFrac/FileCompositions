using FileCompositions.Core.FileSystem.Request;
using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.FileSystem;

public partial interface IFileSystem
{
    internal sealed IFileSystemSource RequestSource() => new Source(this);

    // not a record tho
    private sealed record Source : IFileSystemSource
    {
        private bool disposed = false;

        private IFileSystem FileSystem => !disposed
            ? field
            : throw new ObjectDisposedException($"{typeof(IFileSystemSource)} is out of scope and has been disposed.");

        public Source(in IFileSystem fileSystem) => FileSystem = fileSystem;

        public Task RequestAsync(FileSystemRequest request, CancellationToken cancellationToken) => request(FileSystem, cancellationToken);
        public Task<TResult> RequestAsync<TResult>(FileSystemRequest<TResult> request, CancellationToken cancellationToken) => request(FileSystem, cancellationToken);
        public ValueTask RequestAsync(FileSystemValueRequest request, CancellationToken cancellationToken = default) => request(FileSystem, cancellationToken);
        public ValueTask<TResult> RequestAsync<TResult>(FileSystemValueRequest<TResult> request, CancellationToken cancellationToken = default) => request(FileSystem, cancellationToken);

        public void Dispose() => Interlocked.Exchange(ref disposed, true);
    }
}
