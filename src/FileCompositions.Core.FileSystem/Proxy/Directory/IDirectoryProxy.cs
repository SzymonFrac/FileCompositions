namespace FileCompositions.Core.FileSystem.Proxy.Directory;

internal interface IDirectoryProxy
{
    Task<bool> ExistsAsync(CancellationToken cancellationToken = default);
    Task CreateAsync(CancellationToken cancellationToken = default);
    Task DeleteAsync(CancellationToken cancellationToken = default);
}
