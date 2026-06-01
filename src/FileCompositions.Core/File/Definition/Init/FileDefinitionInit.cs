using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Definition.Init;

internal static class FileDefinitionInit
{
    extension(IFileDefinitionInit<StrictDefinition, RequiredInRequired> init)
    {
        public async ValueTask InitAsync(CancellationToken cancellationToken = default)
        {
            if (!await init.StorageBackend.ExistsAsync(init.GetLocation(), cancellationToken))
                await init.StorageBackend.CreateAsync(init.GetLocation(), cancellationToken);
        }
    }

    extension(IFileDefinitionInit<ExternalDefinition, RequiredInRequired> init)
    {
        public async ValueTask InitAsync(CancellationToken cancellationToken = default)
        {
            if (!await init.StorageBackend.ExistsAsync(init.GetLocation(), cancellationToken).ConfigureAwait(false))
                throw new FileNotFoundException("A required, external file must exist.");
        }
    }

    extension(IFileDefinitionInit<StrictDefinition, OptionalInRequired> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IFileDefinitionInit<ExternalDefinition, OptionalInRequired> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IFileDefinitionInit<StrictDefinition, OptionalInOptional> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IFileDefinitionInit<ExternalDefinition, OptionalInOptional> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }
}
