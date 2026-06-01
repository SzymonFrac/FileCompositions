using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Initializer.Implementations;

internal class HostResourceSchemaFileInitializer<TDefinition, TOwnsership, TPlacement>(FileDefinitionKey key) : IHostResourceSchemaInitializer
    where TDefinition : IFileDefinition<TOwnsership, TPlacement>
    where TOwnsership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    private readonly FileDefinitionKey _key = key;
    public ValueTask InitializeAsync(IServiceProvider services, CancellationToken cancellationToken = default) =>
        services.GetRequiredKeyedService<TDefinition>(_key)
            .InitializeAsync(cancellationToken);
}
