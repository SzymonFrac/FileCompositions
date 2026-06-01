using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Location.Implementations;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Address.Implementations;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Location.Builder.Implementations;

file sealed class DirectoryLocationBuilder<TBackend> : IDirectoryLocationBuilder<TBackend>
    where TBackend : class, IStorageBackend
{
    private StorageAddress? address;

    public IDirectoryLocationBuilder<TBackend> WithAddress(StorageAddress a)
    {
        address = a;
        return this;
    }
    public IDirectoryLocationBuilder<TNewBackend> ToStorageBackend<TNewBackend>()
        where TNewBackend : class, IStorageBackend =>
            new DirectoryLocationBuilder<TNewBackend>();

    public IDirectoryLocation Build(in IDirectoryContext context) =>
        address is null
            ? throw new NullReferenceException($"{nameof(address)} was null.")
            : new DirectoryLocation(context, address);
}

internal sealed class DirectoryLocationBuilder : IDirectoryLocationBuilder
{
    private LocalStorageAddress? address;

    public IDirectoryLocationBuilder WithAddress(LocalStorageAddress a)
    {
        address = a;
        return this;
    }
    public IDirectoryLocationBuilder<TNewBackend> ToStorageBackend<TNewBackend>()
        where TNewBackend : class, IStorageBackend =>
            new DirectoryLocationBuilder<TNewBackend>();

    public IDirectoryLocation Build(in IDirectoryContext context) =>
        address is null
        ? throw new NullReferenceException($"{nameof(address)} was null.")
        : new DirectoryLocation(context, address);
}
