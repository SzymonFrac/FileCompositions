using FileCompositions.Core.FileSystem.Addressing;

namespace FileCompositions.Core.FileSystem;

public partial interface IFileSystem
{
    Task<Stream> OpenReadAsync(Location location, CancellationToken cancellationToken = default);
    Task<Stream> OpenWriteAsync(Location location, CancellationToken cancellationToken = default);
    Task<Stream> OpenAppendAsync(Location location, CancellationToken cancellationToken = default);
    Task<Stream> OpenCreateAsync(Location location, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Address address, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Location location, CancellationToken cancellationToken = default);
    Task CreateAsync(Address address, CancellationToken cancellationToken = default);
    Task CreateAsync(Location location, CancellationToken cancellationToken = default);
    Task DeleteAsync(Address address, CancellationToken cancellationToken = default);
    Task DeleteAsync(Location location, CancellationToken cancellationToken = default);
}
