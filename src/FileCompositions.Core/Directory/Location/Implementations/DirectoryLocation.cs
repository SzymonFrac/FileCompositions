using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Location.Abstract;
using FileCompositions.Core.Storage.Address;

namespace FileCompositions.Core.Directory.Location.Implementations;

internal sealed class DirectoryLocation(IDirectoryContext context, StorageAddress address) : AbstractDirectoryLocation(context, address);