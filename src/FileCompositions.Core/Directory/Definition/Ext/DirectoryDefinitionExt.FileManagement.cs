using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Definition.Ext;

public static partial class DirectoryDefinitionExt
{
    extension(IDirectoryDefinition<Ownership.Internal, Necessity.Required> directory)
    {

    }

    extension(IDirectoryDefinition<Ownership.External, Necessity.Required> directory)
    {

    }

    extension(IDirectoryDefinition<Ownership.Internal, Necessity.Optional> directory)
    {
        public Task CreateAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync((proxy, ct) => proxy.CreateAsync(ct), cancellationToken);

        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync((proxy, ct) => proxy.DeleteAsync(ct), cancellationToken);

        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync((proxy, ct) => proxy.ExistsAsync(ct), cancellationToken);
    }

    extension(IDirectoryDefinition<Ownership.External, Necessity.Optional> directory)
    {
        public Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync((proxy, ct) => proxy.ExistsAsync(ct), cancellationToken);
    }
}
