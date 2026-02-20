using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.DirectoryLocation.Builder.Mux;

public interface IDirectoryLocationBuilderMux
{
    IDirectoryLocationBuilder New(Action<IDirectoryLocationBuilder> config);
    IDirectoryLocationBuilder New<TBackend>(Action<IDirectoryLocationBuilder> config)
        where TBackend : class, IStorageBackend;
}
