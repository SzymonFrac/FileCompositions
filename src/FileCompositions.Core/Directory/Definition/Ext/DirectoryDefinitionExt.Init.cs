using FileCompositions.Core.Exception.ExternalRequiredMissing;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Definition.Ext;

public static partial class DirectoryDefinitionExt
{
    extension(IDirectoryDefinition<Ownership.Internal, Necessity.Required> directory)
    {
        internal Task InitAsync(CancellationToken cancellationToken = default) =>
            directory.ProxySource.RequestAsync((proxy, ct) => proxy.CreateAsync(ct), cancellationToken);
    }

    extension(IDirectoryDefinition<Ownership.External, Necessity.Required> directory)
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

    extension(IDirectoryDefinition<Ownership.Internal, Necessity.Optional> directory)
    {
        internal Task InitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }

    extension(IDirectoryDefinition<Ownership.External, Necessity.Optional> directory)
    {
        internal Task InitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }
}
