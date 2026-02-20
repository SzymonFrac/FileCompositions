using FileCompositions.Core.DirectoryLocation.Context;
using FileCompositions.Core.DirectoryLocation.StorageConnector;
using FileCompositions.Core.Storage.Address;

namespace FileCompositions.Core.DirectoryLocation;

internal interface IDirectoryLocation : IDirectoryLocationStorageConnector
{
    IDirectoryLocationContext Context { get; }
    StorageAddress Address { get; }
}
