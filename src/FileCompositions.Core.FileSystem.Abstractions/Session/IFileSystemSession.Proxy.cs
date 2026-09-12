using FileCompositions.Core.FileSystem.Abstractions.Proxy;

namespace FileCompositions.Core.FileSystem.Abstractions.Session;

internal partial interface IFileSystemSession
{
    sealed IFileSystemProxy<TEntry> RequestProxy<TEntry>(in TEntry entry)
        where TEntry : Entry =>
            new Proxy<TEntry>(this, entry);

    private sealed record Proxy<TEntry> : IFileSystemProxy<TEntry>
            where TEntry : Entry
    {
        public IFileSystemSession Session { get; }
        public TEntry Entry { get; }

        public Proxy(in IFileSystemSession session, in TEntry entry) => (Session, Entry) = (session, entry);
    }
}
