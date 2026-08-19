using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Name;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Request;

namespace FileCompositions.Core.File.Resource.Abstract;

internal abstract class AbstractFileResource(IFileContext context, FileName name) : IFileResource
{
    private readonly IFileContext _context = context;
    public FileName Name { get; } = name;

    public FileSystemAddress RequestAddress() => _context.Address;

    public Task RequestFileSystemAsync(FileSystemRequest.Location request, CancellationToken cancellationToken) =>
        _context.RequestFileSystemAsync(request, this, cancellationToken);
    public Task<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest.Location<TResult> request, CancellationToken cancellationToken) =>
        _context.RequestFileSystemAsync(request, this, cancellationToken);
}
