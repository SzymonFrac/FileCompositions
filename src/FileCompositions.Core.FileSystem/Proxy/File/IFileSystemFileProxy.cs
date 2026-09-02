namespace FileCompositions.Core.FileSystem.Proxy.File;

internal interface IFileSystemFileProxy : IFileSystemProxy
{
    public Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default);
    public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default);
    public Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default);
    public Task<Stream> OpenCreateAsync(CancellationToken cancellationToken = default);

    public Task<bool> ExistsAsync(CancellationToken cancellationToken = default);
    public Task<bool> AddressExistsAsync(CancellationToken cancellationToken = default);
    public Task CreateAsync(CancellationToken cancellationToken = default);
    public Task DeleteAsync(CancellationToken cancellationToken = default);
}
