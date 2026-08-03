using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Quality.Ext;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Request;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.File.Resource.Abstract;

internal abstract class AbstractFileResource(IFileContext context, FileSystemResourceName name) : IFileResource
{
    private readonly IFileContext _context = context;
    public FileSystemResourceName Name { get; } = name;

    public FileSystemAddress RequestAddress() => _context.Address;

    public Task RequestFileSystemAsync(FileSystemRequest request, CancellationToken cancellationToken) =>
        _context.RequestFileSystemAsync(request, this.GetLocation(), cancellationToken);
    public Task<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest<TResult> request, CancellationToken cancellationToken) =>
        _context.RequestFileSystemAsync(request, this.GetLocation(), cancellationToken);
}
