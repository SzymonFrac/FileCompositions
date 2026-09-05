using FileCompositions.Core.FileSystem.Addressing.Directory;
using FileCompositions.Core.FileSystem.Session.Source;

namespace FileCompositions.Core.File.Context;

internal interface IFileContext
{
    IFileSystemSessionSource SessionSource { get; }
    FileSystemDirectoryAddressing DirectoryAddressing { get; }

    //FileSystemAddress Address { get; }

    //Task RequestFileSystemAsync(FileSystemRequest request, IFileAddressing addressing, CancellationToken cancellationToken = default);
    //Task<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest<TResult> request, IFileAddressing addressing, CancellationToken cancellationToken = default);
}

