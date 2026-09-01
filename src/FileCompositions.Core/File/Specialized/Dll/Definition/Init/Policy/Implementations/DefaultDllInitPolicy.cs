using FileCompositions.Core.File.Definition.Ext;
using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Diagnostics;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Init.Policy.Implementations;

internal sealed partial class DefaultDllInitPolicy<TOwnership, TPlacement> : IDllInitPolicy<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public Func<CancellationToken, Task> GetPolicy(IDllDefinition<TOwnership, TPlacement> init) => init switch
    {
        IDllDefinition<StrictDefinition, RequiredInRequired> sr => sr.InitDllAsync,
        IDllDefinition<ExternalDefinition, RequiredInRequired> er => er.InitDllAsync,
        IDllDefinition<StrictDefinition, OptionalInRequired> so => so.InitDllAsync,
        IDllDefinition<ExternalDefinition, OptionalInRequired> eo => eo.InitDllAsync,
        IDllDefinition<StrictDefinition, OptionalInOptional> soo => soo.InitDllAsync,
        IDllDefinition<ExternalDefinition, OptionalInOptional> eoo => eoo.InitDllAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultDllInitPolicy
{
    extension(IDllDefinition<StrictDefinition, RequiredInRequired> dll)
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

    extension(IDllDefinition<ExternalDefinition, RequiredInRequired> dll)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinition<StrictDefinition, OptionalInRequired> dll)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinition<ExternalDefinition, OptionalInRequired> dll)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinition<StrictDefinition, OptionalInOptional> dll)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinition<ExternalDefinition, OptionalInOptional> dll)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }
}
