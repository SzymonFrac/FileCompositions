using FileCompositions.Core.File.Definition.Ext;
using FileCompositions.Core.FileSystem.Proxy.File.Request;
using FileCompositions.Core.Quality;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Init.Policy.Implementations;

internal class MigrateDbInitPolicy<TOwnership, TPlacement, TDbContext> : IDbInitPolicy<TOwnership, TPlacement, TDbContext>
    where TOwnership : Ownership
    where TPlacement : Placement
    where TDbContext : DbContext
{
    public Func<TDbContext, CancellationToken, Task> GetPolicy(IDbDefinition<TOwnership, TPlacement, TDbContext> init) => init switch
    {
        IDbDefinition<Ownership.Internal, Placement.RequiredInRequired, TDbContext> sr => sr.MigrateDbAsync,
        IDbDefinition<Ownership.External, Placement.RequiredInRequired, TDbContext> er => er.MigrateDbAsync,
        IDbDefinition<Ownership.Internal, Placement.OptionalInRequired, TDbContext> so => so.MigrateDbAsync,
        IDbDefinition<Ownership.External, Placement.OptionalInRequired, TDbContext> eo => eo.MigrateDbAsync,
        IDbDefinition<Ownership.Internal, Placement.OptionalInOptional, TDbContext> soo => soo.MigrateDbAsync,
        IDbDefinition<Ownership.External, Placement.OptionalInOptional, TDbContext> eoo => eoo.MigrateDbAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class MigrateDbInitPolicy
{
    extension<TDbContext>(IDbDefinition<Ownership.Internal, Placement.RequiredInRequired, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task MigrateDbAsync(TDbContext dbContext, CancellationToken cancellationToken = default) =>
            dbContext.Database.MigrateAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<Ownership.External, Placement.RequiredInRequired, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task MigrateDbAsync(TDbContext dbContext, CancellationToken cancellationToken = default) =>
            //await db.InitAsync(cancellationToken);
            dbContext.Database.MigrateAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<Ownership.Internal, Placement.OptionalInRequired, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task MigrateDbAsync(TDbContext dbContext, CancellationToken cancellationToken = default) =>
            db.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (await proxy.ExistsAsync(ct).ConfigureAwait(false))
                    await dbContext.Database.MigrateAsync(ct).ConfigureAwait(false);
            }),
                cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<Ownership.External, Placement.OptionalInRequired, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task MigrateDbAsync(TDbContext dbContext, CancellationToken cancellationToken = default) =>
            db.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<Ownership.Internal, Placement.OptionalInOptional, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task MigrateDbAsync(TDbContext dbContext, CancellationToken cancellationToken = default) =>
            db.ProxySource.RequestAsync((FileSystemFileProxyRequest)(async (proxy, ct) =>
            {
                if (await proxy.ExistsAsync(ct).ConfigureAwait(false))
                    await dbContext.Database.MigrateAsync(ct).ConfigureAwait(false);
            }),
                cancellationToken);
        
    }

    extension<TDbContext>(IDbDefinition<Ownership.External, Placement.OptionalInOptional, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task MigrateDbAsync(TDbContext dbContext, CancellationToken cancellationToken = default) =>
            db.InitAsync(cancellationToken);
    }
}
