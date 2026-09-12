using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.FileSystem.Abstractions;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;
using FileCompositions.Core.FileSystem.Abstractions.Proxy.Source;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Definition.Abstract;

internal abstract class AbstractFileDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, Filename name)
    : IFileDefinition<TOwnership, TPlacement>
        where TOwnership : Ownership
        where TPlacement : Placement
{
    private readonly IFileContext _context = context;
    private readonly Filename _name = name;

    public FileDefinitionKey Key { get; } = key;
    public FileAddressing Addressing => field ??= new(_context.DirectoryAddressing, _name);
    public IFileSystemProxySource<Entry.File> ProxySource => field ??= _context.SessionSource.RequestProxySource(Addressing);

    public abstract Task InitializeAsync(CancellationToken cancellationToken = default);
}