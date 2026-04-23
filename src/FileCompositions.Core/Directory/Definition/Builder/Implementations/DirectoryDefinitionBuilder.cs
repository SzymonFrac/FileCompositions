using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.Directory.Definition.Descriptor.Implementations;
using FileCompositions.Core.Directory.Definition.Implementations;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Definition.Builder.Implementations;

internal sealed class DirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend> :
     IDirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend
{
    private DirectoryDefinitionKey key;
    private StorageAddress address;

    public DirectoryDefinitionBuilder() { }
    private DirectoryDefinitionBuilder(DirectoryDefinitionKey k, StorageAddress a) => (key, address) = (k, a);

    public IDirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend> WithKey(DirectoryDefinitionKey k)
    {
        key = k;
        return this;
    }
    public IDirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend> WithAddress(StorageAddress a)
    {
        address = a;
        return this;
    }
    public IDirectoryDefinitionBuilder<TOwnership, TNecessity, TNewBackend> ToStorageBackend<TNewBackend>()
        where TNewBackend : class, IStorageBackend =>
            new DirectoryDefinitionBuilder<TOwnership, TNecessity, TNewBackend>(key, address);

    public IDirectoryDefinitionBuilder<ExternalDefinition, TNecessity, TBackend> External() =>
        new DirectoryDefinitionBuilder<ExternalDefinition, TNecessity, TBackend>(key, address);
    public IDirectoryDefinitionBuilder<StrictDefinition, TNecessity, TBackend> Strict() =>
        new DirectoryDefinitionBuilder<StrictDefinition, TNecessity, TBackend>(key, address);
    public IDirectoryDefinitionBuilder<TOwnership, RequiredDefinition, TBackend> Required() =>
        new DirectoryDefinitionBuilder<TOwnership, RequiredDefinition, TBackend>(key, address);
    public IDirectoryDefinitionBuilder<TOwnership, OptionalDefinition, TBackend> Optional() =>
        new DirectoryDefinitionBuilder<TOwnership, OptionalDefinition, TBackend>(key, address);

    public IDirectoryDefinition<TOwnership, TNecessity> Build(in IDirectoryContext context) =>
        new DirectoryDefinition<TOwnership, TNecessity>(key, context, address);
    public IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend> BuildDescriptor() =>
        new DirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend>(key, address);


    IDirectoryDefinitionBuilder<TOwnership, TNecessity> IDirectoryDefinitionBuilder<TOwnership, TNecessity>.WithKey(DirectoryDefinitionKey key) => WithKey(key);
    IDirectoryDefinitionBuilder<TOwnership, TNecessity> IDirectoryDefinitionBuilder<TOwnership, TNecessity>.WithAddress(StorageAddress address) => WithAddress(address);
    
    IDirectoryDefinitionBuilder<ExternalDefinition, TNecessity> IDirectoryDefinitionBuilder<TOwnership, TNecessity>.External() => External();
    IDirectoryDefinitionBuilder<StrictDefinition, TNecessity> IDirectoryDefinitionBuilder<TOwnership, TNecessity>.Strict() => Strict();
    IDirectoryDefinitionBuilder<TOwnership, RequiredDefinition> IDirectoryDefinitionBuilder<TOwnership, TNecessity>.Required() => Required();
    IDirectoryDefinitionBuilder<TOwnership, OptionalDefinition> IDirectoryDefinitionBuilder<TOwnership, TNecessity>.Optional() => Optional();
}
