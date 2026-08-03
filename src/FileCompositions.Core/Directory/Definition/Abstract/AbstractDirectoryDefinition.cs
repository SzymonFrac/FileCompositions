using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Ext;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Request;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using System.Diagnostics;

namespace FileCompositions.Core.Directory.Definition.Abstract;

internal abstract class AbstractDirectoryDefinition<TOwnership, TNecessity>(IDirectoryContext context, DirectoryDefinitionKey key, FileSystemAddress address)
    : IDirectoryDefinition<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    public IDirectoryContext Context { get; } = context;

    public DirectoryDefinitionKey Key { get; } = key;
    public FileSystemAddress Address { get; } = address;


    public ValueTask RequestFileSystemAsync(FileSystemRequest.Address request, CancellationToken cancellationToken) =>
        Context.RequestFileSystemAsync(request, this, cancellationToken);
    public ValueTask<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest.Address<TResult> request, CancellationToken cancellationToken) =>
        Context.RequestFileSystemAsync(request, this, cancellationToken);

    public ValueTask InitializeAsync(CancellationToken cancellationToken) => this switch
    {
        IDirectoryDefinition<StrictDefinition, RequiredDefinition> sr => sr.InitAsync(cancellationToken),
        IDirectoryDefinition<StrictDefinition, OptionalDefinition> so => so.InitAsync(cancellationToken),
        IDirectoryDefinition<ExternalDefinition, RequiredDefinition> er => er.InitAsync(cancellationToken),
        IDirectoryDefinition<ExternalDefinition, OptionalDefinition> eo => eo.InitAsync(cancellationToken),
        _ => throw new UnreachableException()
    };
}
