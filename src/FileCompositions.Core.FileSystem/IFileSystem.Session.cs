using FileCompositions.Core.FileSystem.Session;
using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.FileSystem;

public partial interface IFileSystem
{
    internal IFileSystemSession RequestSession() => Session.Request(this);

    private sealed class Session : IFileSystemSession
    {
        private bool disposed = false;

        public IFileSystemSource Source => !disposed
            ? field
            : throw new ObjectDisposedException($"{typeof(IFileSystemSource)} is out of scope and has been disposed.");

        private Session(ref readonly IFileSystemSource source) => Source = source;
        public static Session Request(in IFileSystem fileSystem)
        {
            var source = fileSystem.RequestSource();
            return new(ref source);
        }

        public void Dispose() => Interlocked.Exchange(ref disposed, true);
    }
}
