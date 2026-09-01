namespace FileCompositions.Core.FileSystem.Proxy.File;

internal interface IFileSystemFileProxy : IFileSystemProxy
{
    public Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default);
    public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default);
    public Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default);
    public Task<Stream> OpenCreateAsync(CancellationToken cancellationToken = default);

    public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default);
    public ValueTask<bool> AddressExistsAsync(CancellationToken cancellationToken = default);
    public ValueTask CreateAsync(CancellationToken cancellationToken = default);
    public ValueTask DeleteAsync(CancellationToken cancellationToken = default);
}
