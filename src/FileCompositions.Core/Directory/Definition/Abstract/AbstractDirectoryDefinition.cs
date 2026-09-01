using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Ext;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Request;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Addressing.Directory;
using FileCompositions.Core.FileSystem.Proxy.Directory.Source;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using System.Diagnostics;

namespace FileCompositions.Core.Directory.Definition.Abstract;

internal abstract class AbstractDirectoryDefinition<TOwnership, TNecessity>(IDirectoryContext context, DirectoryDefinitionKey key, FileSystemAddress address)
    : IDirectoryDefinition<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    private readonly IDirectoryContext _context = context;
    private readonly FileSystemAddress _address = address;

    public DirectoryDefinitionKey Key { get; } = key;
    public FileSystemDirectoryAddressing Addressing => field ??= new(_address);

    public IFileSystemDirectoryProxySource ProxySource => field ??= _context.SessionSource.RequestProxySource(Addressing);

    public TDefinition RequestFileDefinition<TRequestOwnership, TRequestPlacement, TDefinition>(FileDefinitionRequest<TRequestOwnership, TRequestPlacement, TDefinition> request)
        where TRequestOwnership : DefinitionOwnership
        where TRequestPlacement : DefinitionPlacement
        where TDefinition : IFileDefinition<TRequestOwnership, TRequestPlacement>
    {
        var context = new FileContext(_context.SessionSource, Addressing);
        return request(context);
    }

    public ValueTask InitializeAsync(CancellationToken cancellationToken) => this switch
    {
        IDirectoryDefinition<StrictDefinition, RequiredDefinition> sr => sr.InitAsync(cancellationToken),
        IDirectoryDefinition<StrictDefinition, OptionalDefinition> so => so.InitAsync(cancellationToken),
        IDirectoryDefinition<ExternalDefinition, RequiredDefinition> er => er.InitAsync(cancellationToken),
        IDirectoryDefinition<ExternalDefinition, OptionalDefinition> eo => eo.InitAsync(cancellationToken),
        _ => throw new UnreachableException()
    };


    //public Task RequestFileSystemAsync(FileSystemDirectoryProxyRequest request, CancellationToken cancellationToken)
    //{
    //    using var session = _context.SessionSource.Create();
    //    var proxy = session.RequestProxy(Addressing);

    //    return request(proxy, cancellationToken);
    //}
    //    //_context.SessionSource.RequestAsync((in session, ct) =>
    //    //    request(session.RequestProxy(Addressing), ct), cancellationToken);
    //public Task<TResult> RequestFileSystemAsync<TResult>(FileSystemDirectoryProxyRequest<TResult> request, CancellationToken cancellationToken) =>
    //    _context.SessionSource.RequestAsync((in session, ct) =>
    //        request(session.RequestProxy(Addressing), ct), cancellationToken);
    //public ValueTask RequestFileSystemAsync(FileSystemDirectoryProxyValueRequest request, CancellationToken cancellationToken) =>
    //    _context.SessionSource.RequestAsync((in session, ct) =>
    //        request(session.RequestProxy(Addressing), ct), cancellationToken);
    //public ValueTask<TResult> RequestFileSystemAsync<TResult>(FileSystemDirectoryProxyValueRequest<TResult> request, CancellationToken cancellationToken) =>
    //    _context.SessionSource.RequestAsync((in session, ct) =>
    //        request(session.RequestProxy(Addressing), ct), cancellationToken);
}
