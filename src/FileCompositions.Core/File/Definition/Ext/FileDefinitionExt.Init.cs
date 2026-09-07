using FileCompositions.Core.Exception.ExternalRequiredMissing;
using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Definition.Ext;

public static partial class FileDefinitionExt
{
    extension(IFileDefinition<Ownership.Internal, Placement.RequiredInRequired> file)
    {
        public Task InitAsync(CancellationToken cancellationToken = default) =>
            file.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (!await proxy.ExistsAsync(ct).ConfigureAwait(false))
                    await proxy.CreateAsync(ct).ConfigureAwait(false);
            }),
                cancellationToken);
    }

    extension(IFileDefinition<Ownership.External, Placement.RequiredInRequired> file)
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

    extension(IFileDefinition<Ownership.Internal, Placement.OptionalInRequired> file)
    {
        public Task InitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }

    extension(IFileDefinition<Ownership.External, Placement.OptionalInRequired> file)
    {
        public Task InitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }

    extension(IFileDefinition<Ownership.Internal, Placement.OptionalInOptional> file)
    {
        public Task InitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }

    extension(IFileDefinition<Ownership.External, Placement.OptionalInOptional> file)
    {
        public Task InitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }
}
