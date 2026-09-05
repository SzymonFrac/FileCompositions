using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Session.Source;

namespace FileCompositions.Core.Directory.Context.Implementations;

internal sealed class DirectoryContext(IFileSystemSessionSource source) : IDirectoryContext
{
    public IFileSystem FileSystem => throw new NotImplementedException();
    public IFileSystemSessionSource SessionSource { get; } = source;
}
