using FileCompositions.Core.File.Definition.Ext;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using System.Diagnostics;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Init.Policy.Implementations;

internal sealed partial class DefaultDbInitPolicy<TOwnership, TPlacement> : IDbInitPolicy<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public Func<CancellationToken, Task> GetPolicy(IDbDefinition<TOwnership, TPlacement> init) => init switch
    {
        IDbDefinition<StrictDefinition, RequiredInRequired> sr => sr.InitDbAsync,
        IDbDefinition<ExternalDefinition, RequiredInRequired> er => er.InitDbAsync,
        IDbDefinition<StrictDefinition, OptionalInRequired> so => so.InitDbAsync,
        IDbDefinition<ExternalDefinition, OptionalInRequired> eo => eo.InitDbAsync,
        IDbDefinition<StrictDefinition, OptionalInOptional> soo => soo.InitDbAsync,
        IDbDefinition<ExternalDefinition, OptionalInOptional> eoo => eoo.InitDbAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultDbInitPolicy
{
    extension(IDbDefinition<StrictDefinition, RequiredInRequired> init)
    {
        public Task InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinition<ExternalDefinition, RequiredInRequired> init)
    {
        public Task InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinition<StrictDefinition, OptionalInRequired> init)
    {
        public Task InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinition<ExternalDefinition, OptionalInRequired> init)
    {
        public Task InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinition<StrictDefinition, OptionalInOptional> init)
    {
        public Task InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinition<ExternalDefinition, OptionalInOptional> init)
    {
        public Task InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }
}
