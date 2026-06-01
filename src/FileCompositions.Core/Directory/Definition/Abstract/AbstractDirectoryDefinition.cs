using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Init;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.Directory.Operator;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Definition.Abstract;

internal abstract class AbstractDirectoryDefinition<TOwnership, TNecessity>(IDirectoryContext context, DirectoryDefinitionKey key, StorageAddress address)
    : IDirectoryDefinition<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    public IDirectoryContext Context { get; } = context;

    public DirectoryDefinitionKey Key { get; } = key;
    public StorageAddress Address { get; } = address;

    IStorageBackend IDirectoryInterface<TOwnership, TNecessity>.StorageBackend => Context.StorageBackend;
    IStorageBackend IDirectoryDefinitionInit<TOwnership, TNecessity>.StorageBackend => Context.StorageBackend;
    IStorageBackend IDirectoryOperator<TOwnership, TNecessity>.StorageBackend => Context.StorageBackend;
}
