using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition;
using FileCompositions.Hosting.ResourceSchema.Initializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.Initialize.Implementations;

internal sealed class HostResourceSchemaDbInitializer<TOwnsership, TPlacement, TDbContext>(FileDefinitionKey key) : IHostResourceSchemaInitializer
    where TOwnsership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext
{
    private readonly FileDefinitionKey _key = key;
    public ValueTask InitializeAsync(IServiceProvider services, CancellationToken cancellationToken = default) =>
        services.GetRequiredKeyedService<IDbDefinition<TOwnsership, TPlacement, TDbContext>>(_key)
            .InitializeAsync(services.GetRequiredService<TDbContext>(), cancellationToken);
}
