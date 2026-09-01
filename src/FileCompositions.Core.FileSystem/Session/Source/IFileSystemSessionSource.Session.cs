using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.FileSystem.Session.Source;

internal partial interface IFileSystemSessionSource
{
    sealed protected Session RequestSession() => new(RequestSource());

    protected readonly ref partial struct Session : IDisposable
    {
        private readonly IFileSystemSource _source;

        internal Session(IFileSystemSource source) => _source = source;

        public readonly void Dispose() => _source.Dispose();
    }
}
