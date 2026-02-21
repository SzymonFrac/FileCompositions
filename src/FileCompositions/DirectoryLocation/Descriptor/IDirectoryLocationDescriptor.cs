using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend.ActivationContext;
using FileCompositions.Core.Storage.Backend.Provider;

namespace FileCompositions.Core.DirectoryLocation.Descriptor;

internal interface IDirectoryLocationDescriptor
{
    DirectoryLocationKey Key { get; }
    IStorageBackendProvider BackendProvider { get; }
    StorageAddress Address { get; }
    IDirectoryLocation Activate(IStorageBackendActivationContext context);
}
