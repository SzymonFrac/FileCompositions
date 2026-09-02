using FileCompositions.Core.Exception.ExternalRequiredMissing;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Directory.Definition.Ext;

public static partial class DirectoryDefinitionExt
{
    extension(IDirectoryDefinition<StrictDefinition, RequiredDefinition> directory)
    {
        internal Task InitAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync((proxy, ct) => proxy.CreateAsync(ct), cancellationToken);
    }

    extension(IDirectoryDefinition<ExternalDefinition, RequiredDefinition> directory)
    {
        internal Task InitAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync(async (proxy, ct) =>
            {
                if (!await proxy.ExistsAsync(ct))
                    throw new ExternalRequiredDirectoryMissingException("A required, external directory must exist.")
                    {
                        Address = directory.Addressing.Address,
                        Key = directory.Key
                    };
            },
                cancellationToken);
    }

    extension(IDirectoryDefinition<StrictDefinition, OptionalDefinition> directory)
    {
        internal Task InitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }

    extension(IDirectoryDefinition<ExternalDefinition, OptionalDefinition> directory)
    {
        internal Task InitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }
}
