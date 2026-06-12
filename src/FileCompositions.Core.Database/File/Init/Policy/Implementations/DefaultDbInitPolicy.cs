using FileCompositions.Core.File.Init;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Diagnostics;

namespace FileCompositions.Core.Database.File.Init.Policy.Implementations;

internal sealed partial class DefaultDbInitPolicy<TOwnership, TPlacement> : IDbInitPolicy<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public Func<CancellationToken, ValueTask> GetPolicy(IDbInit<TOwnership, TPlacement> init) => init switch
    {
        IDbInit<StrictDefinition, RequiredInRequired> sr => sr.InitDbAsync,
        IDbInit<ExternalDefinition, RequiredInRequired> er => er.InitDbAsync,
        IDbInit<StrictDefinition, OptionalInRequired> so => so.InitDbAsync,
        IDbInit<ExternalDefinition, OptionalInRequired> eo => eo.InitDbAsync,
        IDbInit<StrictDefinition, OptionalInOptional> soo => soo.InitDbAsync,
        IDbInit<ExternalDefinition, OptionalInOptional> eoo => eoo.InitDbAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultDbInitPolicy
{
    extension(IDbInit<StrictDefinition, RequiredInRequired> init)
    {
        public ValueTask InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbInit<ExternalDefinition, RequiredInRequired> init)
    {
        public ValueTask InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbInit<StrictDefinition, OptionalInRequired> init)
    {
        public ValueTask InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbInit<ExternalDefinition, OptionalInRequired> init)
    {
        public ValueTask InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbInit<StrictDefinition, OptionalInOptional> init)
    {
        public ValueTask InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbInit<ExternalDefinition, OptionalInOptional> init)
    {
        public ValueTask InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }
}
