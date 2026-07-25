using FileCompositions.Core.File.Definition.Ext;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Init.Policy.Implementations;

internal sealed class DefaultDbInitPolicy<TOwnership, TPlacement, TDbContext> : IDbInitPolicy<TOwnership, TPlacement, TDbContext>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext
{
    public Func<TDbContext, CancellationToken, ValueTask> GetPolicy(IDbDefinition<TOwnership, TPlacement, TDbContext> init) => init switch
    {
        IDbDefinition<StrictDefinition, RequiredInRequired, TDbContext> sr => sr.InitDbAsync,
        IDbDefinition<ExternalDefinition, RequiredInRequired, TDbContext> er => er.InitDbAsync,
        IDbDefinition<StrictDefinition, OptionalInRequired, TDbContext> so => so.InitDbAsync,
        IDbDefinition<ExternalDefinition, OptionalInRequired, TDbContext> eo => eo.InitDbAsync,
        IDbDefinition<StrictDefinition, OptionalInOptional, TDbContext> soo => soo.InitDbAsync,
        IDbDefinition<ExternalDefinition, OptionalInOptional, TDbContext> eoo => eoo.InitDbAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultDbInitPolicy
{
    extension<TDbContext>(IDbDefinition<StrictDefinition, RequiredInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<ExternalDefinition, RequiredInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<StrictDefinition, OptionalInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<ExternalDefinition, OptionalInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<StrictDefinition, OptionalInOptional, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<ExternalDefinition, OptionalInOptional, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }
}