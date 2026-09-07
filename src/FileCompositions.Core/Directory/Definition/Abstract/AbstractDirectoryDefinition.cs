using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Ext;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Request;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Addressing.Directory;
using FileCompositions.Core.FileSystem.Proxy.Directory.Source;
using FileCompositions.Core.Quality;
using System.Diagnostics;

namespace FileCompositions.Core.Directory.Definition.Abstract;

internal abstract class AbstractDirectoryDefinition<TOwnership, TNecessity>(IDirectoryContext context, DirectoryDefinitionKey key, FileSystemAddress address)
    : IDirectoryDefinition<TOwnership, TNecessity>
        where TOwnership : Ownership
        where TNecessity : Necessity
{
    private readonly IDirectoryContext _context = context;
    private readonly FileSystemAddress _address = address;

    public DirectoryDefinitionKey Key { get; } = key;
    public FileSystemDirectoryAddressing Addressing => field ??= new(_address);

    public IFileSystemDirectoryProxySource ProxySource => field ??= _context.SessionSource.RequestProxySource(Addressing);

    public TDefinition RequestFileDefinition<TRequestOwnership, TRequestPlacement, TDefinition>(FileDefinitionRequest<TRequestOwnership, TRequestPlacement, TDefinition> request)
        where TRequestOwnership : Ownership
        where TRequestPlacement : Placement
        where TDefinition : IFileDefinition<TRequestOwnership, TRequestPlacement>
    {
        var context = new FileContext(_context.SessionSource, Addressing);
        return request(context);
    }

    public Task InitializeAsync(CancellationToken cancellationToken) => this switch
    {
        IDirectoryDefinition<Ownership.Internal, Necessity.Required> sr => sr.InitAsync(cancellationToken),
        IDirectoryDefinition<Ownership.Internal, Necessity.Optional> so => so.InitAsync(cancellationToken),
        IDirectoryDefinition<Ownership.External, Necessity.Required> er => er.InitAsync(cancellationToken),
        IDirectoryDefinition<Ownership.External, Necessity.Optional> eo => eo.InitAsync(cancellationToken),
        _ => throw new UnreachableException()
    };
}
