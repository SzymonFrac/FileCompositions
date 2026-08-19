using FileCompositions.Core.File.Definition.Ext;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Init.Policy.Implementations;

internal class MigrateDbInitPolicy<TOwnership, TPlacement, TDbContext> : IDbInitPolicy<TOwnership, TPlacement, TDbContext>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext
{
    public Func<TDbContext, CancellationToken, Task> GetPolicy(IDbDefinition<TOwnership, TPlacement, TDbContext> init) => init switch
    {
        IDbDefinition<StrictDefinition, RequiredInRequired, TDbContext> sr => sr.MigrateDbAsync,
        IDbDefinition<ExternalDefinition, RequiredInRequired, TDbContext> er => er.MigrateDbAsync,
        IDbDefinition<StrictDefinition, OptionalInRequired, TDbContext> so => so.MigrateDbAsync,
        IDbDefinition<ExternalDefinition, OptionalInRequired, TDbContext> eo => eo.MigrateDbAsync,
        IDbDefinition<StrictDefinition, OptionalInOptional, TDbContext> soo => soo.MigrateDbAsync,
        IDbDefinition<ExternalDefinition, OptionalInOptional, TDbContext> eoo => eoo.MigrateDbAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class MigrateDbInitPolicy
{
    extension<TDbContext>(IDbDefinition<StrictDefinition, RequiredInRequired, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task MigrateDbAsync(TDbContext dbContext, CancellationToken cancellationToken = default) =>
            dbContext.Database.MigrateAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<ExternalDefinition, RequiredInRequired, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task MigrateDbAsync(TDbContext dbContext, CancellationToken cancellationToken = default) =>
            //await db.InitAsync(cancellationToken);
            dbContext.Database.MigrateAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<StrictDefinition, OptionalInRequired, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task MigrateDbAsync(TDbContext dbContext, CancellationToken cancellationToken = default) =>
            db.RequestFileSystemAsync(async (fss, ct) =>
            {
                if (await fss.ExistsAsync(ct).ConfigureAwait(false))
                    await dbContext.Database.MigrateAsync(ct).ConfigureAwait(false);
            },
                cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<ExternalDefinition, OptionalInRequired, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task MigrateDbAsync(TDbContext dbContext, CancellationToken cancellationToken = default) =>
            db.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinition<StrictDefinition, OptionalInOptional, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task MigrateDbAsync(TDbContext dbContext, CancellationToken cancellationToken = default) =>
            db.RequestFileSystemAsync(async (fss, ct) =>
            {
                if (await fss.ExistsAsync(ct).ConfigureAwait(false))
                    await dbContext.Database.MigrateAsync(ct).ConfigureAwait(false);
            },
                cancellationToken);
        
    }

    extension<TDbContext>(IDbDefinition<ExternalDefinition, OptionalInOptional, TDbContext> db)
        where TDbContext : DbContext
    {
        public Task MigrateDbAsync(TDbContext dbContext, CancellationToken cancellationToken = default) =>
            db.InitAsync(cancellationToken);
    }
}
