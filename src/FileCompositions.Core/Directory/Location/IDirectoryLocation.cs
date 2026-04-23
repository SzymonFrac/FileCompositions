using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.StorageConnector;
using FileCompositions.Core.Storage.Address;

namespace FileCompositions.Core.Directory.Location;

internal interface IDirectoryLocation : IDirectoryStorageConnector
{
    IDirectoryContext Context { get; }
    StorageAddress Address { get; }
}
