using FileCompositions.Core.File.Definition.Init;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Quality.Placement.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Init.Policy.Implementations;

internal class MigrateDbDefinitionInitPolicy<TOwnership, TPlacement, TDbContext> : IDbDefinitionInitPolicy<TOwnership, TPlacement, TDbContext>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext
{
    public Func<TDbContext, CancellationToken, ValueTask> GetPolicy(IDbDefinitionInit<TOwnership, TPlacement, TDbContext> init) => init switch
    {
        IDbDefinitionInit<StrictDefinition, RequiredInRequired, TDbContext> sr => sr.MigrateDbAsync,
        IDbDefinitionInit<ExternalDefinition, RequiredInRequired, TDbContext> er => er.MigrateDbAsync,
        IDbDefinitionInit<StrictDefinition, OptionalInRequired, TDbContext> so => so.MigrateDbAsync,
        IDbDefinitionInit<ExternalDefinition, OptionalInRequired, TDbContext> eo => eo.MigrateDbAsync,
        IDbDefinitionInit<StrictDefinition, OptionalInOptional, TDbContext> soo => soo.MigrateDbAsync,
        IDbDefinitionInit<ExternalDefinition, OptionalInOptional, TDbContext> eoo => eoo.MigrateDbAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class MigrateDbDefinitionInitPolicy
{
    extension<TDbContext>(IDbDefinitionInit<StrictDefinition, RequiredInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public async ValueTask MigrateDbAsync(TDbContext db, CancellationToken cancellationToken = default) =>
            await db.Database.MigrateAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinitionInit<ExternalDefinition, RequiredInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public async ValueTask MigrateDbAsync(TDbContext db, CancellationToken cancellationToken = default)
        {
            await init.InitAsync(cancellationToken);

            await db.Database.MigrateAsync(cancellationToken);
        }
    }

    extension<TDbContext>(IDbDefinitionInit<StrictDefinition, OptionalInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public async ValueTask MigrateDbAsync(TDbContext db, CancellationToken cancellationToken = default)
        {
            if (await init.StorageBackend.ExistsAsync(init.GetLocation(), cancellationToken))
                await db.Database.MigrateAsync(cancellationToken);
        }
    }

    extension<TDbContext>(IDbDefinitionInit<ExternalDefinition, OptionalInRequired, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask MigrateDbAsync(TDbContext db, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension<TDbContext>(IDbDefinitionInit<StrictDefinition, OptionalInOptional, TDbContext> init)
        where TDbContext : DbContext
    {
        public async ValueTask MigrateDbAsync(TDbContext db, CancellationToken cancellationToken = default)
        {
            if (await init.StorageBackend.ExistsAsync(init.GetLocation(), cancellationToken))
                await db.Database.MigrateAsync(cancellationToken);
        }
    }

    extension<TDbContext>(IDbDefinitionInit<ExternalDefinition, OptionalInOptional, TDbContext> init)
        where TDbContext : DbContext
    {
        public ValueTask MigrateDbAsync(TDbContext db, CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }
}
