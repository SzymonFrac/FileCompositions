using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Ext;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Request;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Request;
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

    public DirectoryDefinitionKey Key { get; } = key;
    public FileSystemAddress Address { get; } = address;


    public TDefinition RequestFileDefinition<TRequestOwnership, TRequestPlacement, TDefinition>(FileDefinitionRequest<TRequestOwnership, TRequestPlacement, TDefinition> request)
        where TRequestOwnership : DefinitionOwnership
        where TRequestPlacement : DefinitionPlacement
        where TDefinition : IFileDefinition<TRequestOwnership, TRequestPlacement>
    {
        var context = new FileContext(_context.FileSystem, Address);
        return request(context);
    }

    public ValueTask RequestFileSystemAsync(FileSystemRequest.Address request, CancellationToken cancellationToken) =>
        _context.RequestFileSystemAsync(request, this, cancellationToken);
    public ValueTask<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest.Address<TResult> request, CancellationToken cancellationToken) =>
        _context.RequestFileSystemAsync(request, this, cancellationToken);

    public ValueTask InitializeAsync(CancellationToken cancellationToken) => this switch
    {
        IDirectoryDefinition<StrictDefinition, RequiredDefinition> sr => sr.InitAsync(cancellationToken),
        IDirectoryDefinition<StrictDefinition, OptionalDefinition> so => so.InitAsync(cancellationToken),
        IDirectoryDefinition<ExternalDefinition, RequiredDefinition> er => er.InitAsync(cancellationToken),
        IDirectoryDefinition<ExternalDefinition, OptionalDefinition> eo => eo.InitAsync(cancellationToken),
        _ => throw new UnreachableException()
    };


}
