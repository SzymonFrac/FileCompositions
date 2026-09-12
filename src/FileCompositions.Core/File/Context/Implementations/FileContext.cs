using FileCompositions.Core.FileSystem.Abstractions.Addressing;
using FileCompositions.Core.FileSystem.Abstractions.Session.Source;

namespace FileCompositions.Core.File.Context.Implementations;

internal sealed class FileContext(IFileSystemSessionSource sessionSource, DirectoryAddressing directoryAddressing) : IFileContext
{
    public IFileSystemSessionSource SessionSource { get; } = sessionSource;
    public DirectoryAddressing DirectoryAddressing { get; } = directoryAddressing;
}
