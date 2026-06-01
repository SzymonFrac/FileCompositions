using FileCompositions.Core.File.Definition.Init;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Diagnostics;

namespace FileCompositions.Core.Database.File.Definition.Db.Init.Policy.Implementations;

internal sealed partial class DefaultDbDefinitionInitPolicy<TOwnership, TPlacement> : IDbDefinitionInitPolicy<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public Func<CancellationToken, ValueTask> GetPolicy(IDbDefinitionInit<TOwnership, TPlacement> init) => init switch
    {
        IDbDefinitionInit<StrictDefinition, RequiredInRequired> sr => sr.InitDbAsync,
        IDbDefinitionInit<ExternalDefinition, RequiredInRequired> er => er.InitDbAsync,
        IDbDefinitionInit<StrictDefinition, OptionalInRequired> so => so.InitDbAsync,
        IDbDefinitionInit<ExternalDefinition, OptionalInRequired> eo => eo.InitDbAsync,
        IDbDefinitionInit<StrictDefinition, OptionalInOptional> soo => soo.InitDbAsync,
        IDbDefinitionInit<ExternalDefinition, OptionalInOptional> eoo => eoo.InitDbAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultDbDefinitionInitPolicy
{
    extension(IDbDefinitionInit<StrictDefinition, RequiredInRequired> init)
    {
        public ValueTask InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinitionInit<ExternalDefinition, RequiredInRequired> init)
    {
        public ValueTask InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinitionInit<StrictDefinition, OptionalInRequired> init)
    {
        public ValueTask InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinitionInit<ExternalDefinition, OptionalInRequired> init)
    {
        public ValueTask InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinitionInit<StrictDefinition, OptionalInOptional> init)
    {
        public ValueTask InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinitionInit<ExternalDefinition, OptionalInOptional> init)
    {
        public ValueTask InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }
}
