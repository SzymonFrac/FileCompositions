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
using FileCompositions.Core.Storage.Address.Implementations;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Backend.Implementations;

namespace FileCompositions.Core.Directory.Definition.Builder.Implementations;

file sealed class DirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend>(DirectoryDefinitionKey k) : IDirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBackend : class, IStorageBackend
{
    private DirectoryDefinitionKey key = k;
    private StorageAddress? address;

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
            new DirectoryDefinitionBuilder<TOwnership, TNecessity, TNewBackend>(key);

    public IDirectoryDefinitionBuilder<ExternalDefinition, TNecessity, TBackend> External() =>
        new DirectoryDefinitionBuilder<ExternalDefinition, TNecessity, TBackend>(key);
    public IDirectoryDefinitionBuilder<StrictDefinition, TNecessity, TBackend> Strict() =>
        new DirectoryDefinitionBuilder<StrictDefinition, TNecessity, TBackend>(key);
    public IDirectoryDefinitionBuilder<TOwnership, RequiredDefinition, TBackend> Required() =>
        new DirectoryDefinitionBuilder<TOwnership, RequiredDefinition, TBackend>(key);
    public IDirectoryDefinitionBuilder<TOwnership, OptionalDefinition, TBackend> Optional() =>
        new DirectoryDefinitionBuilder<TOwnership, OptionalDefinition, TBackend>(key);

    public IDirectoryDefinition<TOwnership, TNecessity> Build(in IDirectoryContext context) =>
        address is null
            ? throw new NullReferenceException($"{nameof(address)} was null.")
            : new DirectoryDefinition<TOwnership, TNecessity>(context, key, address);
    public IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend> BuildDescriptor() =>
        address is null
            ? throw new NullReferenceException($"{nameof(address)} was null.")
            : new DirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend>(key, address);
}

internal sealed class DirectoryDefinitionBuilder<TOwnership, TNecessity> : IDirectoryDefinitionBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    private DirectoryDefinitionKey key;
    private LocalStorageAddress? address;

    public DirectoryDefinitionBuilder() { }
    private DirectoryDefinitionBuilder(DirectoryDefinitionKey k, LocalStorageAddress? a) => (key, address) = (k, a);

    public IDirectoryDefinitionBuilder<TOwnership, TNecessity> WithKey(DirectoryDefinitionKey k)
    {
        key = k;
        return this;
    }
    public IDirectoryDefinitionBuilder<TOwnership, TNecessity> WithAddress(LocalStorageAddress a)
    {
        address = a;
        return this;
    }
    public IDirectoryDefinitionBuilder<TOwnership, TNecessity, TNewBackend> ToStorageBackend<TNewBackend>()
        where TNewBackend : class, IStorageBackend =>
            new DirectoryDefinitionBuilder<TOwnership, TNecessity, TNewBackend>(key);

    public IDirectoryDefinitionBuilder<ExternalDefinition, TNecessity> External() =>
        new DirectoryDefinitionBuilder<ExternalDefinition, TNecessity>(key, address);
    public IDirectoryDefinitionBuilder<StrictDefinition, TNecessity> Strict() =>
        new DirectoryDefinitionBuilder<StrictDefinition, TNecessity>(key, address);
    public IDirectoryDefinitionBuilder<TOwnership, RequiredDefinition> Required() =>
        new DirectoryDefinitionBuilder<TOwnership, RequiredDefinition>(key, address);
    public IDirectoryDefinitionBuilder<TOwnership, OptionalDefinition> Optional() =>
        new DirectoryDefinitionBuilder<TOwnership, OptionalDefinition>(key, address);

    public IDirectoryDefinition<TOwnership, TNecessity> Build(in IDirectoryContext context) =>
        address is null
            ? throw new NullReferenceException($"{nameof(address)} was null.")
            : new DirectoryDefinition<TOwnership, TNecessity>(context, key, address);
    public IDirectoryDefinitionDescriptor<TOwnership, TNecessity, LocalStorageBackend> BuildDescriptor() =>
        address is null
            ? throw new NullReferenceException($"{nameof(address)} was null.")
            : new DirectoryDefinitionDescriptor<TOwnership, TNecessity, LocalStorageBackend>(key, address);
}
