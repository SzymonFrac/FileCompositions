using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Location;
using static System.IO.FileAccess;
using static System.IO.FileMode;

namespace FileCompositions.Core.FileSystem.Specialized.Local.Implementations;

public sealed class LocalFileSystem : IFileSystem
{
    Task<Stream> IFileSystem.OpenReadAsync(FileSystemLocation location, CancellationToken cancellationToken) =>
                Task.FromResult<Stream>(System.IO.File.OpenRead(location.ToString()));
    Task<Stream> IFileSystem.OpenWriteAsync(FileSystemLocation location, CancellationToken cancellationToken) =>
        Task.FromResult<Stream>(System.IO.File.Create(location.ToString()));
    Task<Stream> IFileSystem.OpenAppendAsync(FileSystemLocation location, CancellationToken cancellationToken) =>
        Task.FromResult<Stream>(System.IO.File.Open(location.ToString(), Append, Write));
    Task<Stream> IFileSystem.OpenCreateAsync(FileSystemLocation location, CancellationToken cancellationToken) =>
        Task.FromResult<Stream>(System.IO.File.Open(location.ToString(), CreateNew, Write));

    ValueTask<bool> IFileSystem.ExistsAsync(FileSystemAddress address, CancellationToken cancellationToken) =>
        ValueTask.FromResult(System.IO.Directory.Exists(address.ToString()));
    ValueTask<bool> IFileSystem.ExistsAsync(FileSystemLocation location, CancellationToken cancellationToken) =>
        ValueTask.FromResult(System.IO.File.Exists(location.ToString()));
    ValueTask IFileSystem.CreateAsync(FileSystemAddress address, CancellationToken cancellationToken)
    {
        System.IO.Directory.CreateDirectory(address.ToString());
        return ValueTask.CompletedTask;
    }
    ValueTask IFileSystem.CreateAsync(FileSystemLocation location, CancellationToken cancellationToken)
    {
        System.IO.File.Create(location.ToString()).Dispose();
        return ValueTask.CompletedTask;
    }
    ValueTask IFileSystem.DeleteAsync(FileSystemAddress address, CancellationToken cancellationToken)
    {
        System.IO.Directory.Delete(address.ToString());
        return ValueTask.CompletedTask;
    }
    ValueTask IFileSystem.DeleteAsync(FileSystemLocation location, CancellationToken cancellationToken)
    {
        System.IO.File.Delete(location.ToString());
        return ValueTask.CompletedTask;
    }
}
