using FileCompositions.Core.DirectoryLocation.Context.Implementations;
using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.DirectoryLocation.Factory.Implementations;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.File.LocationResolver;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Backend.ActivationContext;
using FileCompositions.Core.Storage.Backend.Provider;
using FileCompositions.Core.Storage.Backend.Provider.Implementations;

namespace FileCompositions.Core.DirectoryLocation.Builder.Implementations;

internal class DirectoryLocationBuilder<TOwnership, TNecessity>(IStorageBackendProvider backendProvider, IFileLocationResolver fileResolver)
    : IDirectoryLocationBuilder<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    private readonly DirectoryLocationFactory _factory = new();
    private readonly IFileLocationResolver _fileResolver = fileResolver;

    private StorageAddress address;
    private IStorageBackendProvider storageBackendProvider = backendProvider;

    public IDirectoryLocationBuilder<TOwnership, TNecessity> WithAddress(StorageAddress a)
    {
        address = a;
        return this;
    }
    public IDirectoryLocationBuilder<TOwnership, TNecessity> ToStorageBackend<TStorageBackend>()
        where TStorageBackend : class, IStorageBackend
    {
        storageBackendProvider = new StorageBackendProvider<TStorageBackend>();
        return this;
    }

    public IDirectoryLocationBuilder<ExternalDefinition, TNecessity> External() =>
        new DirectoryLocationBuilder<ExternalDefinition, TNecessity>(storageBackendProvider, _fileResolver);
    public IDirectoryLocationBuilder<StrictDefinition, TNecessity> Strict() =>
        new DirectoryLocationBuilder<StrictDefinition, TNecessity>(storageBackendProvider, _fileResolver);
    public IDirectoryLocationBuilder<TOwnership, RequiredDefinition> Required() =>
        new DirectoryLocationBuilder<TOwnership, RequiredDefinition>(storageBackendProvider, _fileResolver);
    public IDirectoryLocationBuilder<TOwnership, OptionalDefinition> Optional() =>
        new DirectoryLocationBuilder<TOwnership, OptionalDefinition>(storageBackendProvider, _fileResolver);

    public IDirectoryLocation Build(IStorageBackendActivationContext context)
    {
        Validate();

        var backend = context.Activate(storageBackendProvider);
        var directoryContext = new DirectoryLocationContext(backend, _fileResolver);
        var directory = _factory.Create<TOwnership, TNecessity>(directoryContext, address);
        return directory;
    }
    public IDirectoryLocationDescriptor BuildDescriptor(DirectoryLocationKey key)
    {
        Validate();

        var descriptor = _factory.Create(key, storageBackendProvider, address);
        return descriptor;
    }


    private void Validate()
    {
        if (address.Equals(default))
            throw new ArgumentException($"{nameof(address)} must have a value in {nameof(IDirectoryLocationBuilder<,>)}", nameof(address));
    }

}
