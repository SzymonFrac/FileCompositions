using FileCompositions.Core.Exception.ExternalRequiredMissing;
using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Definition.Ext;

public static partial class FileDefinitionExt
{
    extension(IFileDefinition<StrictDefinition, RequiredInRequired> file)
    {
        public Task InitAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (!await proxy.ExistsAsync(ct).ConfigureAwait(false))
                    await proxy.CreateAsync(ct).ConfigureAwait(false);
            }),
                cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, RequiredInRequired> file)
    {
        public Task InitAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (!await proxy.ExistsAsync(ct).ConfigureAwait(false))
                    throw new ExternalRequiredFileMissingException("A required, external file must exist.")
                    {
                        Location = file.Addressing.Location,
                        Key = file.Key
                    };
            }),
                cancellationToken);
    }

    extension(IFileDefinition<StrictDefinition, OptionalInRequired> file)
    {
        public Task InitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInRequired> file)
    {
        public Task InitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }

    extension(IFileDefinition<StrictDefinition, OptionalInOptional> file)
    {
        public Task InitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInOptional> file)
    {
        public Task InitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }
}
