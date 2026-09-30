using FileCompositions.Core.FileSystem.Abstractions.Session.Source;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.File.Context;

internal interface IFileContext
{
    IFileSystemSessionSource SessionSource { get; }
    Address Address { get; }
}
