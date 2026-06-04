using FileCompositions.Core.Exception.ExternalRequiredMissing;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Definition.Custom.Init;

public static class CustomDefinitionInit
{
    extension(ICustomDefinitionInit<StrictDefinition, RequiredInRequired> init)
    {
        public async ValueTask InitAsync(CancellationToken cancellationToken = default)
        {
            if (!await init.StorageBackend.ExistsAsync(init.GetLocation(), cancellationToken))
                await init.StorageBackend.CreateAsync(init.GetLocation(), cancellationToken);
        }
    }

    extension(ICustomDefinitionInit<ExternalDefinition, RequiredInRequired> init)
    {
        public async ValueTask InitAsync(CancellationToken cancellationToken = default)
        {
            if (!await init.StorageBackend.ExistsAsync(init.GetLocation(), cancellationToken).ConfigureAwait(false))
                throw new ExternalRequiredFileMissingException("A required, external file must exist.")
                {
                    Location = init.GetLocation(),
                    Key = init.Key
                };
        }
    }

    extension(ICustomDefinitionInit<StrictDefinition, OptionalInRequired> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(ICustomDefinitionInit<ExternalDefinition, OptionalInRequired> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(ICustomDefinitionInit<StrictDefinition, OptionalInOptional> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(ICustomDefinitionInit<ExternalDefinition, OptionalInOptional> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }
}
