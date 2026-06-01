using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Address.Implementations;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Location.Builder;

public interface IDirectoryLocationBuilder<TBackend>
    where TBackend : class, IStorageBackend
{
    IDirectoryLocationBuilder<TBackend> WithAddress(StorageAddress address);
    IDirectoryLocationBuilder<TNewBackend> ToStorageBackend<TNewBackend>()
        where TNewBackend : class, IStorageBackend;

    internal IDirectoryLocation Build(in IDirectoryContext context);
}

public interface IDirectoryLocationBuilder
{
    IDirectoryLocationBuilder WithAddress(LocalStorageAddress address);
    IDirectoryLocationBuilder<TNewBackend> ToStorageBackend<TNewBackend>()
        where TNewBackend : class, IStorageBackend;

    internal IDirectoryLocation Build(in IDirectoryContext context);
}
