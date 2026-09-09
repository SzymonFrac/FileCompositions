using FileCompositions.Core.FileSystem.Addressing;
using static System.IO.FileAccess;
using static System.IO.FileMode;

namespace FileCompositions.Core.FileSystem.Specialized.Local.Implementations;

public sealed class LocalFileSystem : IFileSystem
{
    Task<Stream> IFileSystem.OpenReadAsync(Location location, CancellationToken cancellationToken) =>
        Task.FromResult<Stream>(File.OpenRead(location.ToString()));
    Task<Stream> IFileSystem.OpenWriteAsync(Location location, CancellationToken cancellationToken) =>
        Task.FromResult<Stream>(File.Create(location.ToString()));
    Task<Stream> IFileSystem.OpenAppendAsync(Location location, CancellationToken cancellationToken) =>
        Task.FromResult<Stream>(File.Open(location.ToString(), Append, Write));
    Task<Stream> IFileSystem.OpenCreateAsync(Location location, CancellationToken cancellationToken) =>
        Task.FromResult<Stream>(File.Open(location.ToString(), CreateNew, Write));

    Task<bool> IFileSystem.ExistsAsync(Address address, CancellationToken cancellationToken) =>
        Task.FromResult(Directory.Exists(address.ToString()));
    Task<bool> IFileSystem.ExistsAsync(Location location, CancellationToken cancellationToken) =>
        Task.FromResult(File.Exists(location.ToString()));
    Task IFileSystem.CreateAsync(Address address, CancellationToken cancellationToken)
    {
        Directory.CreateDirectory(address.ToString());
        return Task.CompletedTask;
    }
    Task IFileSystem.CreateAsync(Location location, CancellationToken cancellationToken)
    {
        File.Create(location.ToString()).Dispose();
        return Task.CompletedTask;
    }
    Task IFileSystem.DeleteAsync(Address address, CancellationToken cancellationToken)
    {
        Directory.Delete(address.ToString());
        return Task.CompletedTask;
    }
    Task IFileSystem.DeleteAsync(Location location, CancellationToken cancellationToken)
    {
        File.Delete(location.ToString());
        return Task.CompletedTask;
    }
}
