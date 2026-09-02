using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Location;

namespace FileCompositions.Core.FileSystem;

public partial interface IFileSystem
{
    Task<Stream> OpenReadAsync(FileSystemLocation location, CancellationToken cancellationToken = default);
    Task<Stream> OpenWriteAsync(FileSystemLocation location, CancellationToken cancellationToken = default);
    Task<Stream> OpenAppendAsync(FileSystemLocation location, CancellationToken cancellationToken = default);
    Task<Stream> OpenCreateAsync(FileSystemLocation location, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(FileSystemAddress address, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(FileSystemLocation location, CancellationToken cancellationToken = default);
    Task CreateAsync(FileSystemAddress address, CancellationToken cancellationToken = default);
    Task CreateAsync(FileSystemLocation location, CancellationToken cancellationToken = default);
    Task DeleteAsync(FileSystemAddress address, CancellationToken cancellationToken = default);
    Task DeleteAsync(FileSystemLocation location, CancellationToken cancellationToken = default);
}
