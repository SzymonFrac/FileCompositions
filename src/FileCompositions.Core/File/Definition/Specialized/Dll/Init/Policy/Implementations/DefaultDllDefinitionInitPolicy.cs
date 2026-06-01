using FileCompositions.Core.File.Definition.Init;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Diagnostics;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Init.Policy.Implementations;

internal sealed partial class DefaultDllDefinitionInitPolicy<TOwnership, TPlacement> : IDllDefinitionInitPolicy<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public Func<CancellationToken, ValueTask> GetPolicy(IDllDefinitionInit<TOwnership, TPlacement> init) => init switch
    {
        IDllDefinitionInit<StrictDefinition, RequiredInRequired> sr => sr.InitDllAsync,
        IDllDefinitionInit<ExternalDefinition, RequiredInRequired> er => er.InitDllAsync,
        IDllDefinitionInit<StrictDefinition, OptionalInRequired> so => so.InitDllAsync,
        IDllDefinitionInit<ExternalDefinition, OptionalInRequired> eo => eo.InitDllAsync,
        IDllDefinitionInit<StrictDefinition, OptionalInOptional> soo => soo.InitDllAsync,
        IDllDefinitionInit<ExternalDefinition, OptionalInOptional> eoo => eoo.InitDllAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultDllDefinitionInitPolicy
{
    extension(IDllDefinitionInit<StrictDefinition, RequiredInRequired> dll)
    {
        public ValueTask InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinitionInit<ExternalDefinition, RequiredInRequired> dll)
    {
        public ValueTask InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinitionInit<StrictDefinition, OptionalInRequired> dll)
    {
        public ValueTask InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinitionInit<ExternalDefinition, OptionalInRequired> dll)
    {
        public ValueTask InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinitionInit<StrictDefinition, OptionalInOptional> dll)
    {
        public ValueTask InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }

    extension(IDllDefinitionInit<ExternalDefinition, OptionalInOptional> dll)
    {
        public ValueTask InitDllAsync(CancellationToken cancellationToken = default) =>
            dll.InitAsync(cancellationToken);
    }
}
