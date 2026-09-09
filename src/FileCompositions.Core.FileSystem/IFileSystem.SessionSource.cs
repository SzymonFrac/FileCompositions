using FileCompositions.Core.FileSystem.Session.Request;
using FileCompositions.Core.FileSystem.Session.Source;

namespace FileCompositions.Core.FileSystem;

public partial interface IFileSystem
{
    internal sealed ISessionSource RequestSessionSource() => new SessionSource(this);

    private sealed record SessionSource : ISessionSource
    {
        private readonly IFileSystem _fileSystem;
        public SessionSource(in IFileSystem fileSystem) => _fileSystem = fileSystem;

        public Task RequestAsync(SessionRequest request, CancellationToken cancellationToken = default)
        {
            using var session = _fileSystem.RequestSession();
            return request(session, cancellationToken);
        }
        public Task<TResult> RequestAsync<TResult>(SessionRequest<TResult> request, CancellationToken cancellationToken = default)
        {
            using var session = _fileSystem.RequestSession();
            return request(session, cancellationToken);
        }
    }
}
