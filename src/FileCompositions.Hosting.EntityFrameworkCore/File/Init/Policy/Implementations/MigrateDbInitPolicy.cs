using FileCompositions.Core.File.Init;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Init.Policy.Implementations;

internal class MigrateDbInitPolicy<TOwnership, TPlacement, TDbContext> : IDbInitPolicy<TOwnership, TPlacement, TDbContext>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext
{
    public Func<TDbContext, CancellationToken, ValueTask> GetPolicy(IDbInit<TOwnership, TPlacement, TDbContext> init) => init switch
    {
        IDbInit<StrictDefinition, RequiredInRequired, TDbContext> sr => sr.MigrateDbAsync,
        IDbInit<ExternalDefinition, RequiredInRequired, TDbContext> er => er.MigrateDbAsync,
        IDbInit<StrictDefinition, OptionalInRequired, TDbContext> so => so.MigrateDbAsync,
        IDbInit<ExternalDefinition, OptionalInRequired, TDbContext> eo => eo.MigrateDbAsync,
        IDbInit<StrictDefinition, OptionalInOptional, TDbContext> soo => soo.MigrateDbAsync,
        IDbInit<ExternalDefinition, OptionalInOptional, TDbContext> eoo => eoo.MigrateDbAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class MigrateDbInitPolicy
{
    extension<TDbContext>(IDbInit<StrictDefinition, RequiredInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public async ValueTask MigrateDbAsync(TDbContext db, CancellationToken cancellationToken = default) =>
            await db.Database.MigrateAsync(cancellationToken);
    }

    extension<TDbContext>(IDbInit<ExternalDefinition, RequiredInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public async ValueTask MigrateDbAsync(TDbContext db, CancellationToken cancellationToken = default)
        {
            await init.InitAsync(cancellationToken);

            await db.Database.MigrateAsync(cancellationToken);
        }
    }

    extension<TDbContext>(IDbInit<StrictDefinition, OptionalInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public async ValueTask MigrateDbAsync(TDbContext db, CancellationToken cancellationToken = default)
        {
            if (await init.StorageBackend.ExistsAsync(init.GetLocation(), cancellationToken))
                await db.Database.MigrateAsync(cancellationToken);
        }
    }

    extension<TDbContext>(IDbInit<ExternalDefinition, OptionalInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask MigrateDbAsync(TDbContext db, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbInit<StrictDefinition, OptionalInOptional, TDbContext> init)
        where TDbContext : DbContext
    {
        public async ValueTask MigrateDbAsync(TDbContext db, CancellationToken cancellationToken = default)
        {
            if (await init.StorageBackend.ExistsAsync(init.GetLocation(), cancellationToken))
                await db.Database.MigrateAsync(cancellationToken);
        }
    }

    extension<TDbContext>(IDbInit<ExternalDefinition, OptionalInOptional, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask MigrateDbAsync(TDbContext db, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }
}
