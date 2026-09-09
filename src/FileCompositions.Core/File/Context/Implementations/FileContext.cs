using FileCompositions.Core.FileSystem.Addressing;
using FileCompositions.Core.FileSystem.Session.Source;

namespace FileCompositions.Core.File.Context.Implementations;

internal sealed class FileContext(ISessionSource sessionSource, DirectoryAddressing directoryAddressing) : IFileContext
{
    public ISessionSource SessionSource { get; } = sessionSource;
    public DirectoryAddressing DirectoryAddressing { get; } = directoryAddressing;
}
