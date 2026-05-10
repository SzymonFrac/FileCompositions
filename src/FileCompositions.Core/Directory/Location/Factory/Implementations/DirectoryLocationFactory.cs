using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Location.Implementations;
using FileCompositions.Core.Storage.Address;

namespace FileCompositions.Core.Directory.Location.Factory.Implementations;

internal class DirectoryLocationFactory : IDirectoryLocationFactory
{
    public IDirectoryLocation Create(IDirectoryContext context, StorageAddress address) =>
        new StandardDirectoryLocation(context, address);
}
