using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Session.Source;

namespace FileCompositions.Core.Directory.Context.Implementations;

internal sealed class DirectoryContext(ISessionSource source) : IDirectoryContext
{
    public IFileSystem FileSystem => throw new NotImplementedException();
    public ISessionSource SessionSource { get; } = source;
}
