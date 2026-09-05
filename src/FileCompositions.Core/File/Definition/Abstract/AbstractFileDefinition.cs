using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.FileSystem.Addressing.File;
using FileCompositions.Core.FileSystem.Name;
using FileCompositions.Core.FileSystem.Proxy.File.Source;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Abstract;

internal abstract class AbstractFileDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, FileSystemFilename name)
    : IFileDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    private readonly IFileContext _context = context;
    private readonly FileSystemFilename _name = name;

    public FileDefinitionKey Key { get; } = key;
    public FileSystemFileAddressing Addressing => field ??= new(_context.DirectoryAddressing, _name);
    public IFileSystemFileProxySource ProxySource => field ??= _context.SessionSource.RequestProxySource(Addressing);

    public abstract Task InitializeAsync(CancellationToken cancellationToken = default);
}