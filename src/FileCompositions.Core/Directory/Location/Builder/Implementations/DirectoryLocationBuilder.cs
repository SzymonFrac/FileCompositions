using FileCompositions.Core.Directory.Context.Implementations;
using FileCompositions.Core.Directory.Location.Implementations;
using FileCompositions.Core.File.LocationResolver;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Location.Builder.Implementations;

internal class DirectoryLocationBuilder(IStorageBackend backend, IFileLocationResolver fileResolver) : IDirectoryLocationBuilder
{
    private readonly IFileLocationResolver _fileResolver = fileResolver;

    private StorageAddress address;
    private IStorageBackend storageBackend = backend;

    public IDirectoryLocationBuilder WithAddress(StorageAddress a)
    {
        address = a;
        return this;
    }
    public IDirectoryLocationBuilder ToStorageBackend<TStorageBackend>()
        where TStorageBackend : class, IStorageBackend, new()
    {
        storageBackend = new TStorageBackend();
        return this;
    }

    public IDirectoryLocation Build()
    {
        Validate();

        var context = new DirectoryContext(storageBackend, _fileResolver);
        var directory = new StandardDirectoryLocation(context, address);
        return directory;
    }

    private void Validate()
    {
        if (address.Equals(default))
            throw new ArgumentException($"{nameof(address)} must have a value in {nameof(IDirectoryLocationBuilder)}", nameof(address));
    }

}
