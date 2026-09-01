using FileCompositions.Core.FileSystem.Addressing.Directory;
using FileCompositions.Core.FileSystem.Session.Source;

namespace FileCompositions.Core.File.Context.Implementations;

internal sealed class FileContext(IFileSystemSessionSource sessionSource, FileSystemDirectoryAddressing directoryAddressing) : IFileContext
{
    public IFileSystemSessionSource SessionSource { get; } = sessionSource;
    public FileSystemDirectoryAddressing DirectoryAddressing { get; } = directoryAddressing;
}
