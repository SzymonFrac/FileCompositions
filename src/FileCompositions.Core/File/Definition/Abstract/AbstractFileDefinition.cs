using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Request;
using FileCompositions.Core.FileSystem.Resource.Name;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Abstract;

internal abstract class AbstractFileDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, FileSystemResourceName name)
    : IFileDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    private readonly IFileContext _context = context;
    public FileDefinitionKey Key { get; } = key;
    public FileSystemResourceName Name { get; } = name;

    public abstract Task InitializeAsync(CancellationToken cancellationToken = default);

    public FileSystemAddress RequestAddress() => _context.Address;

    public Task RequestFileSystemAsync(FileSystemRequest request, CancellationToken cancellationToken) =>
        _context.FileSystemSource.RequestFileSystemAsync(request, cancellationToken);
    public Task<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest<TResult> request, CancellationToken cancellationToken) =>
        _context.FileSystemSource.RequestFileSystemAsync(request, cancellationToken);
}