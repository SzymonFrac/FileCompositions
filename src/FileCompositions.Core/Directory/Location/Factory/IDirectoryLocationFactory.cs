using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Storage.Address;

namespace FileCompositions.Core.Directory.Location.Factory;

internal interface IDirectoryLocationFactory
{
    IDirectoryLocation Create(IDirectoryContext context, StorageAddress address);
}
