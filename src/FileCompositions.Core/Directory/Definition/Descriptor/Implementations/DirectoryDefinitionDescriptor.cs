using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Implementations;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Definition.Descriptor.Implementations;

internal class DirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend>(DirectoryDefinitionKey key, StorageAddress address)
    : IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend
{
    private readonly StorageAddress _address = address;
    public DirectoryDefinitionKey Key { get; private set; } = key;
    public DirectoryDefinitionKey WithKeyIfNull(DirectoryDefinitionKey k)
    {
        if (Key == default)
            Key = k;
        return Key;
    }
    
    public IDirectoryDefinition<TOwnership, TNecessity> Activate(in IDirectoryContext context) =>
        new StandardDirectoryDefinition<TOwnership, TNecessity>(context, Key, _address);

}