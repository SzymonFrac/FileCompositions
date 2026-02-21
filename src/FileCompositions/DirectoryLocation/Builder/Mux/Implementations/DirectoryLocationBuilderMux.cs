using FileCompositions.Core.DirectoryLocation.Builder.Factory;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Backend.Implementations;
using FileCompositions.Core.Storage.Backend.Provider.Implementations;

namespace FileCompositions.Core.DirectoryLocation.Builder.Mux.Implementations;

internal class DirectoryLocationBuilderMux(IDirectoryLocationBuilderFactory defaultFactory) : IDirectoryLocationBuilderMux
{
    private readonly IDirectoryLocationBuilderFactory _defaultFactory = defaultFactory;
    private readonly StorageBackendProvider<LocalDiskStorageBackend> _localStorageBackend = new();
    public IDirectoryLocationBuilder New(Action<IDirectoryLocationBuilder> config)
    {
        var builder = _defaultFactory.Create(_localStorageBackend);
        config(builder);
        return builder;
    }

    public IDirectoryLocationBuilder New<TBackend>(Action<IDirectoryLocationBuilder> config)
        where TBackend : class, IStorageBackend
    {
        var builder = _defaultFactory.Create(new StorageBackendProvider<TBackend>());
        config(builder);
        return builder;
    }
}
