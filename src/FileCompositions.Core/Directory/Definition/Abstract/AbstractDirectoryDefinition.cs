using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Directory.Init;
using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.Directory.Operator;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;
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

    public DirectoryDefinitionKey GetKey() => Key;
    public FileSystemAddress GetAddress() => Address;

    public ValueTask InitializeAsync(CancellationToken cancellationToken = default) => this switch
    {
        IDirectoryDefinition<StrictDefinition, RequiredDefinition> sr => sr.InitAsync(cancellationToken),
        IDirectoryDefinition<ExternalDefinition, RequiredDefinition> er => er.InitAsync(cancellationToken),
        IDirectoryDefinition<StrictDefinition, OptionalDefinition> => default,
        IDirectoryDefinition<ExternalDefinition, OptionalDefinition> => default,
        _ => throw new UnreachableException()
    };

    IFileSystem IDirectoryInterface<TOwnership, TNecessity>.StorageBackend => Context.StorageBackend;
    IFileSystem IDirectoryInit<TOwnership, TNecessity>.StorageBackend => Context.StorageBackend;
    IFileSystem IDirectoryOperator<TOwnership, TNecessity>.StorageBackend => Context.StorageBackend;
}
