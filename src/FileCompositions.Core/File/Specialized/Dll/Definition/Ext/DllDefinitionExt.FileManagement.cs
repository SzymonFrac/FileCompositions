using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Ext;

public static partial class DllDefinitionExt
{
    extension(IDllDefinition<Ownership.Internal, Placement.RequiredInRequired> dll)
    {

    }

    extension(IDllDefinition<Ownership.External, Placement.RequiredInRequired> dll)
    {

    }

    extension(IDllDefinition<Ownership.Internal, Placement.OptionalInRequired> dll)
    {
        public Task CreateAsync(CancellationToken cancellationToken = default) =>
            dll.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (!await proxy.ExistsAsync(ct).ConfigureAwait(false))
                {
                    await using var stream = await proxy.OpenCreateAsync(ct).ConfigureAwait(false);

                    await using var @default = typeof(IDllDefinition<,>).Assembly
                        .GetManifestResourceStream("FileCompositions.Core.Assets.Dll.Default.dll")!;

                    await @default.CopyToAsync(stream, ct).ConfigureAwait(false);
                }
            }),
                cancellationToken);
    }

    extension(IDllDefinition<Ownership.External, Placement.OptionalInRequired> dll)
    {

    }

    extension(IDllDefinition<Ownership.Internal, Placement.OptionalInOptional> dll)
    {
        public Task<bool> TryCreateAsync(CancellationToken cancellationToken = default) =>
            dll.ProxySource.RequestAsync((FileSystemFileProxyRequest<bool>)(async (proxy, ct) =>
            {
                var addressExists = await proxy.AddressExistsAsync(ct).ConfigureAwait(false);
                if (addressExists)
                {
                    await using var stream = await proxy.OpenCreateAsync(ct).ConfigureAwait(false);

                    await using var @default = typeof(IDllDefinition<,>).Assembly
                        .GetManifestResourceStream("FileCompositions.Core.Assets.Dll.Default.dll")!;

                    await @default.CopyToAsync(stream, ct).ConfigureAwait(false);
                }

                return addressExists;
            }),
                cancellationToken);
    }

    extension(IDllDefinition<Ownership.External, Placement.OptionalInOptional> dll)
    {

    }
}
