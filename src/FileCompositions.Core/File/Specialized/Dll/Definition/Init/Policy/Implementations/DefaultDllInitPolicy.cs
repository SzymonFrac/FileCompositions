using FileCompositions.Core.File.Definition.Ext;
using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality;
using System.Diagnostics;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Init.Policy.Implementations;

internal sealed partial class DefaultDllInitPolicy<TOwnership, TPlacement> : IDllInitPolicy<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    public Func<CancellationToken, Task> GetPolicy(IDllDefinition<TOwnership, TPlacement> init) => init switch
    {
        IDllDefinition<Ownership.Internal, Placement.RequiredInRequired> sr => sr.InitDllAsync,
        IDllDefinition<Ownership.External, Placement.RequiredInRequired> er => er.InitDllAsync,
        IDllDefinition<Ownership.Internal, Placement.OptionalInRequired> so => so.InitDllAsync,
        IDllDefinition<Ownership.External, Placement.OptionalInRequired> eo => eo.InitDllAsync,
        IDllDefinition<Ownership.Internal, Placement.OptionalInOptional> soo => soo.InitDllAsync,
        IDllDefinition<Ownership.External, Placement.OptionalInOptional> eoo => eoo.InitDllAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultDllInitPolicy
{
    extension(IDllDefinition<Ownership.Internal, Placement.RequiredInRequired> dll)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
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

    extension(IDllDefinition<Ownership.External, Placement.RequiredInRequired> dll)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinition<Ownership.Internal, Placement.OptionalInRequired> dll)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinition<Ownership.External, Placement.OptionalInRequired> dll)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinition<Ownership.Internal, Placement.OptionalInOptional> dll)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinition<Ownership.External, Placement.OptionalInOptional> dll)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }
}
