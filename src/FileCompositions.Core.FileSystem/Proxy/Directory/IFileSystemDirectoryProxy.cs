namespace FileCompositions.Core.FileSystem.Proxy.Directory;

internal interface IFileSystemDirectoryProxy : IFileSystemProxy
{
    ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default);
    ValueTask CreateAsync(CancellationToken cancellationToken = default);
    ValueTask DeleteAsync(CancellationToken cancellationToken = default);
}
