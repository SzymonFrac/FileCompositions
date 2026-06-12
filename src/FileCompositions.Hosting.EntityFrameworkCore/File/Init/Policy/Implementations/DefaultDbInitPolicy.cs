using FileCompositions.Core.File.Init;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Init.Policy.Implementations;

internal sealed class DefaultDbInitPolicy<TOwnership, TPlacement, TDbContext> : IDbInitPolicy<TOwnership, TPlacement, TDbContext>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext
{
    public Func<TDbContext, CancellationToken, ValueTask> GetPolicy(IDbInit<TOwnership, TPlacement, TDbContext> init) => init switch
    {
        IDbInit<StrictDefinition, RequiredInRequired, TDbContext> sr => sr.InitDbAsync,
        IDbInit<ExternalDefinition, RequiredInRequired, TDbContext> er => er.InitDbAsync,
        IDbInit<StrictDefinition, OptionalInRequired, TDbContext> so => so.InitDbAsync,
        IDbInit<ExternalDefinition, OptionalInRequired, TDbContext> eo => eo.InitDbAsync,
        IDbInit<StrictDefinition, OptionalInOptional, TDbContext> soo => soo.InitDbAsync,
        IDbInit<ExternalDefinition, OptionalInOptional, TDbContext> eoo => eoo.InitDbAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultDbInitPolicy
{
    extension<TDbContext>(IDbInit<StrictDefinition, RequiredInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbInit<ExternalDefinition, RequiredInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbInit<StrictDefinition, OptionalInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbInit<ExternalDefinition, OptionalInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbInit<StrictDefinition, OptionalInOptional, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbInit<ExternalDefinition, OptionalInOptional, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }
}