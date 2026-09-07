using FileCompositions.Core.File.Definition.Ext;
using FileCompositions.Core.Quality;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Init.Policy.Implementations;

internal sealed class DefaultDbInitPolicy<TOwnership, TPlacement, TDbContext> : IDbInitPolicy<TOwnership, TPlacement, TDbContext>
    where TOwnership : Ownership
    where TPlacement : Placement
    where TDbContext : DbContext
{
    public Func<TDbContext, CancellationToken, Task> GetPolicy(IDbDefinition<TOwnership, TPlacement, TDbContext> init) => init switch
    {
        IDbDefinition<Ownership.Internal, Placement.RequiredInRequired, TDbContext> sr => sr.InitDbAsync,
        IDbDefinition<Ownership.External, Placement.RequiredInRequired, TDbContext> er => er.InitDbAsync,
        IDbDefinition<Ownership.Internal, Placement.OptionalInRequired, TDbContext> so => so.InitDbAsync,
        IDbDefinition<Ownership.External, Placement.OptionalInRequired, TDbContext> eo => eo.InitDbAsync,
        IDbDefinition<Ownership.Internal, Placement.OptionalInOptional, TDbContext> soo => soo.InitDbAsync,
        IDbDefinition<Ownership.External, Placement.OptionalInOptional, TDbContext> eoo => eoo.InitDbAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultDbInitPolicy
{
    extension<TDbContext>(IDbDefinition<Ownership.Internal, Placement.RequiredInRequired, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            db.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<Ownership.External, Placement.RequiredInRequired, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            db.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<Ownership.Internal, Placement.OptionalInRequired, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            db.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<Ownership.External, Placement.OptionalInRequired, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            db.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<Ownership.Internal, Placement.OptionalInOptional, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            db.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<Ownership.External, Placement.OptionalInOptional, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task InitDbAsync(TDbContext _, CancellationToken cancellationToken = default) =>
            db.InitAsync(cancellationToken);
    }
}