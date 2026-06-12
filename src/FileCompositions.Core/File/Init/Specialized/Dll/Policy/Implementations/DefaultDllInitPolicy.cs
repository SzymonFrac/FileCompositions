using FileCompositions.Core.File.Operator.Specialized.Dll;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Diagnostics;

namespace FileCompositions.Core.File.Init.Specialized.Dll.Policy.Implementations;

internal sealed partial class DefaultDllInitPolicy<TOwnership, TPlacement> : IDllInitPolicy<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public Func<CancellationToken, ValueTask> GetPolicy(IDllInit<TOwnership, TPlacement> init) => init switch
    {
        IDllInit<StrictDefinition, RequiredInRequired> sr => sr.InitDllAsync,
        IDllInit<ExternalDefinition, RequiredInRequired> er => er.InitDllAsync,
        IDllInit<StrictDefinition, OptionalInRequired> so => so.InitDllAsync,
        IDllInit<ExternalDefinition, OptionalInRequired> eo => eo.InitDllAsync,
        IDllInit<StrictDefinition, OptionalInOptional> soo => soo.InitDllAsync,
        IDllInit<ExternalDefinition, OptionalInOptional> eoo => eoo.InitDllAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultDllInitPolicy
{
    extension(IDllInit<StrictDefinition, RequiredInRequired> dll)
    {
        public async ValueTask InitDllAsync(CancellationToken cancellationToken = default)
        {
            if (!await dll.StorageBackend.ExistsAsync(dll.GetLocation(), cancellationToken).ConfigureAwait(false))
            {
                await using var stream = await dll.StorageBackend.OpenCreateAsync(dll.GetLocation(), cancellationToken).ConfigureAwait(false);

                await using var @default = typeof(IDllOperator<,>).Assembly
                    .GetManifestResourceStream("FileCompositions.Core.Assets.Dll.Default.dll")!;

                await @default.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    extension(IDllInit<ExternalDefinition, RequiredInRequired> dll)
    {
        public ValueTask InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllInit<StrictDefinition, OptionalInRequired> dll)
    {
        public ValueTask InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllInit<ExternalDefinition, OptionalInRequired> dll)
    {
        public ValueTask InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllInit<StrictDefinition, OptionalInOptional> dll)
    {
        public ValueTask InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllInit<ExternalDefinition, OptionalInOptional> dll)
    {
        public ValueTask InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }
}
