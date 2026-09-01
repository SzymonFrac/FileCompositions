using FileCompositions.Core.FileSystem.Session.Source;
using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.FileSystem;

public partial interface IFileSystem
{
    internal sealed IFileSystemSessionSource RequestSessionSource() => new SessionSource(this);

    private sealed record SessionSource : IFileSystemSessionSource
    {
        private readonly IFileSystem _fileSystem;
        public SessionSource(IFileSystem fileSystem) => _fileSystem = fileSystem;

        public IFileSystemSource RequestSource() => _fileSystem.RequestSource();


        //public FileSystemSession Create()
        //{
        //    var source = _fileSystem.RequestSource();
        //    return new FileSystemSession(source);
        //}

        //public Task RequestAsync(FileSystemSessionRequest request, CancellationToken cancellationToken = default)
        //{
        //    var source = _fileSystem.RequestSource();
        //    using var session = new FileSystemSession(ref source);

        //    return request(in session, cancellationToken);
        //}

        //public Task<TResult> RequestAsync<TResult>(FileSystemSessionRequest<TResult> request, CancellationToken cancellationToken = default)
        //{
        //    var source = _fileSystem.RequestSource();
        //    using var session = new FileSystemSession(ref source);

        //    return request(in session, cancellationToken);
        //}

        //public ValueTask RequestAsync(FileSystemSessionValueRequest request, CancellationToken cancellationToken = default)
        //{
        //    var source = _fileSystem.RequestSource();
        //    using var session = new FileSystemSession(ref source);

        //    return request(in session, cancellationToken);
        //}

        //public ValueTask<TResult> RequestAsync<TResult>(FileSystemSessionValueRequest<TResult> request, CancellationToken cancellationToken = default)
        //{
        //    var source = _fileSystem.RequestSource();
        //    using var session = new FileSystemSession(ref source);

        //    return request(in session, cancellationToken);
        //}
    }
}
