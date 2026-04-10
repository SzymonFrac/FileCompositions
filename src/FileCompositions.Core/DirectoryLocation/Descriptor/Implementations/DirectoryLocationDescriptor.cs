using FileCompositions.Core.DirectoryLocation.Builder.Factory.Implementations;
using FileCompositions.Core.DirectoryLocation.Context.Implementations;
using FileCompositions.Core.DirectoryLocation.Factory.Implementations;
using FileCompositions.Core.DirectoryLocation.Implementations;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend.ActivationContext;
using FileCompositions.Core.Storage.Backend.Provider;

namespace FileCompositions.Core.DirectoryLocation.Descriptor.Implementations;

// Should directories be descriptors?
internal class DirectoryLocationDescriptor(DirectoryLocationKey key, IStorageBackendProvider backendProvider, StorageAddress address) : IDirectoryLocationDescriptor
{
    public DirectoryLocationKey Key { get; } = key;
    public IStorageBackendProvider BackendProvider { get; } = backendProvider;
    public StorageAddress Address { get; } = address;

    public IDirectoryLocation Activate(IStorageBackendActivationContext context)
    {
        var storageBackend = context.Activate(BackendProvider);
        var directoryContext = new DirectoryLocationContext(storageBackend);

        var directory = new DirectoryLocation<StrictDefinition, RequiredDefinition>(directoryContext, Address);
        return directory;
    }
}
