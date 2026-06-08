using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Location;

namespace FileCompositions.Core.FileSystem;

public interface IFileSystem
{
    Task<Stream> OpenReadAsync(FileSystemLocation location, CancellationToken cancellationToken = default);
    Task<Stream> OpenWriteAsync(FileSystemLocation location, CancellationToken cancellationToken = default);
    Task<Stream> OpenAppendAsync(FileSystemLocation location, CancellationToken cancellationToken = default);
    Task<Stream> OpenCreateAsync(FileSystemLocation location, CancellationToken cancellationToken = default);

    ValueTask<bool> ExistsAsync(FileSystemAddress address, CancellationToken cancellationToken = default);
    ValueTask<bool> ExistsAsync(FileSystemLocation location, CancellationToken cancellationToken = default);
    ValueTask CreateAsync(FileSystemAddress address, CancellationToken cancellationToken = default);
    ValueTask CreateAsync(FileSystemLocation location, CancellationToken cancellationToken = default);
    ValueTask DeleteAsync(FileSystemAddress address, CancellationToken cancellationToken = default);
    ValueTask DeleteAsync(FileSystemLocation location, CancellationToken cancellationToken = default);
}
