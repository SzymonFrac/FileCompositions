using FileCompositions.Core.Exception.ExternalRequiredMissing;
using FileCompositions.Core.FileSystem.Proxy.Directory.Request;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Directory.Definition.Ext;

public static partial class DirectoryDefinitionExt
{
    extension(IDirectoryDefinition<StrictDefinition, RequiredDefinition> directory)
    {
        internal ValueTask InitAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync((proxy, ct) => proxy.CreateAsync(ct), cancellationToken);
    }

    extension(IDirectoryDefinition<ExternalDefinition, RequiredDefinition> directory)
    {
        internal ValueTask InitAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync((FileSystemDirectoryProxyValueRequest)(async (proxy, ct) =>
            {
                if (!await proxy.ExistsAsync(ct))
                    throw new ExternalRequiredDirectoryMissingException("A required, external directory must exist.")
                    {
                        Address = directory.Addressing.Address,
                        Key = directory.Key
                    };
            }),
                cancellationToken);
    }

    extension(IDirectoryDefinition<StrictDefinition, OptionalDefinition> directory)
    {
        internal ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IDirectoryDefinition<ExternalDefinition, OptionalDefinition> directory)
    {
        internal ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }
}
