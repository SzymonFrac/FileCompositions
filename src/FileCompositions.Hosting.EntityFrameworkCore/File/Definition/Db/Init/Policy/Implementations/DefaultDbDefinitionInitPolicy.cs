using FileCompositions.Core.File.Definition.Init;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Init.Policy.Implementations;

internal sealed class DefaultDbDefinitionInitPolicy<TOwnership, TPlacement, TDbContext> : IDbDefinitionInitPolicy<TOwnership, TPlacement, TDbContext>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext
{
    public Func<TDbContext, CancellationToken, ValueTask> GetPolicy(IDbDefinitionInit<TOwnership, TPlacement, TDbContext> init) => init switch
    {
        IDbDefinitionInit<StrictDefinition, RequiredInRequired, TDbContext> sr => sr.InitDbAsync,
        IDbDefinitionInit<ExternalDefinition, RequiredInRequired, TDbContext> er => er.InitDbAsync,
        IDbDefinitionInit<StrictDefinition, OptionalInRequired, TDbContext> so => so.InitDbAsync,
        IDbDefinitionInit<ExternalDefinition, OptionalInRequired, TDbContext> eo => eo.InitDbAsync,
        IDbDefinitionInit<StrictDefinition, OptionalInOptional, TDbContext> soo => soo.InitDbAsync,
        IDbDefinitionInit<ExternalDefinition, OptionalInOptional, TDbContext> eoo => eoo.InitDbAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultDbDefinitionInitPolicy
{
    extension<TDbContext>(IDbDefinitionInit<StrictDefinition, RequiredInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinitionInit<ExternalDefinition, RequiredInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinitionInit<StrictDefinition, OptionalInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinitionInit<ExternalDefinition, OptionalInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinitionInit<StrictDefinition, OptionalInOptional, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinitionInit<ExternalDefinition, OptionalInOptional, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }
}