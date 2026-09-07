using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.ResourceSchema.Initializer.Implementations;

internal sealed class HostResourceSchemaDirectoryInitializer<TOwnership, TNecessity>(DirectoryDefinitionKey key) : IHostResourceSchemaInitializer
    where TOwnership : Ownership
    where TNecessity : Necessity
{
    private readonly DirectoryDefinitionKey _key = key;
    public Task InitializeAsync(IServiceProvider services, CancellationToken cancellationToken = default) =>
        services.GetRequiredKeyedService<IDirectoryDefinition<TOwnership, TNecessity>>(_key)
            .InitializeAsync(cancellationToken);
}
