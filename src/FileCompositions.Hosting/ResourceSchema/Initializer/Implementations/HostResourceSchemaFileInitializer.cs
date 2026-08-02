using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.ResourceSchema.Initializer.Implementations;

internal sealed class HostResourceSchemaFileInitializer<TDefinition, TOwnsership, TPlacement>(FileDefinitionKey key) : IHostResourceSchemaInitializer
    where TDefinition : IFileDefinition<TOwnsership, TPlacement>
    where TOwnsership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    private readonly FileDefinitionKey _key = key;
    public Task InitializeAsync(IServiceProvider services, CancellationToken cancellationToken = default) =>
        services.GetRequiredKeyedService<TDefinition>(_key)
            .InitializeAsync(cancellationToken);
}
