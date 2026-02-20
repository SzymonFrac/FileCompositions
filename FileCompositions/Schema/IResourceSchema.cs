using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Storage.Backend.ActivationContext;

namespace FileCompositions.Core.Schema;

internal interface IResourceSchema
{
    IStorageBackendActivationContext ActivationContext { get; }

    IDirectoryLocation? GetDirectoryLocation(DirectoryLocationKey key);
}
