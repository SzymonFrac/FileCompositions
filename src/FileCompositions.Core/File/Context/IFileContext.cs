using FileCompositions.Core.FileSystem.Abstractions.Addressing;
using FileCompositions.Core.FileSystem.Abstractions.Session.Source;

namespace FileCompositions.Core.File.Context;

internal interface IFileContext
{
    IFileSystemSessionSource SessionSource { get; }
    DirectoryAddressing DirectoryAddressing { get; }
}
