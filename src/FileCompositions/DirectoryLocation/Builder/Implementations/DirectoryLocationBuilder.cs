using FileCompositions.Core.DirectoryLocation.Context.Implementations;
using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.DirectoryLocation.Factory;
using FileCompositions.Core.DirectoryLocation.Factory.Implementations;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Backend.ActivationContext;
using FileCompositions.Core.Storage.Backend.Provider;
using FileCompositions.Core.Storage.Backend.Provider.Implementations;

namespace FileCompositions.Core.DirectoryLocation.Builder.Implementations;

internal class DirectoryLocationBuilder(IStorageBackendProvider backendProvider) : IDirectoryLocationBuilder
{
    private IDirectoryLocationFactory factory = new DirectoryLocationFactory();

    private StorageAddress address;
    private IStorageBackendProvider storageBackendProvider = backendProvider;

    public IDirectoryLocationBuilder WithAddress(StorageAddress a)
    {
        address = a;
        return this;
    }
    public IDirectoryLocationBuilder ToStorageBackend<TStorageBackend>()
        where TStorageBackend : class, IStorageBackend
    {
        storageBackendProvider = new StorageBackendProvider<TStorageBackend>();
        return this;
    }

    public IDirectoryLocationBuilder UseFactory(IDirectoryLocationFactory f)
    {
        factory = f;
        return this;
    }
    public IDirectoryLocation Build(IStorageBackendActivationContext context)
    {
        Validate();

        var backend = context.Activate(storageBackendProvider);
        var directoryContext = new DirectoryLocationContext(backend);
        var directory = factory.Create(directoryContext, address);
        return directory;
    }
    public IDirectoryLocationDescriptor BuildDescriptor(DirectoryLocationKey key)
    {
        Validate();

        var descriptor = factory.Create(key, storageBackendProvider, address);
        return descriptor;
    }


    private void Validate()
    {
        if (address.Equals(default))
            throw new ArgumentException($"{nameof(address)} must have a value in {nameof(IDirectoryLocationBuilder)}", nameof(address));
    }

}
