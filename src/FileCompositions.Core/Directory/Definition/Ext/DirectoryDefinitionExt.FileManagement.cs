using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Directory.Definition.Ext;

public static partial class DirectoryDefinitionExt
{
    extension(IDirectoryDefinition<StrictDefinition, RequiredDefinition> directory)
    {

    }

    extension(IDirectoryDefinition<ExternalDefinition, RequiredDefinition> directory)
    {

    }

    extension(IDirectoryDefinition<StrictDefinition, OptionalDefinition> directory)
    {
        public ValueTask CreateAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync((proxy, ct) => proxy.CreateAsync(ct), cancellationToken);

        public ValueTask DeleteAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync((proxy, ct) => proxy.DeleteAsync(ct), cancellationToken);

        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync((proxy, ct) => proxy.ExistsAsync(ct), cancellationToken);
    }

    extension(IDirectoryDefinition<ExternalDefinition, OptionalDefinition> directory)
    {
        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync((proxy, ct) => proxy.ExistsAsync(ct), cancellationToken);
    }
}
