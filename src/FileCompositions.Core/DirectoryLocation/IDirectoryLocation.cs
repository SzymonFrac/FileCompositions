using FileCompositions.Core.DirectoryLocation.Context;
using FileCompositions.Core.DirectoryLocation.StorageConnector;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Location.Extensions;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.DirectoryLocation;

internal interface IDirectoryLocation : IDirectoryLocationStorageConnector
{
    IDirectoryLocationContext Context { get; }
    StorageAddress Address { get; }
    // If it gets Location, then dont expose Address?
    StorageLocation GetLocation(StorageResourceName name) => Address.With(name);
}
