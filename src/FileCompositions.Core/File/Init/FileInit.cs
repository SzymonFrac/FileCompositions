using FileCompositions.Core.Exception.ExternalRequiredMissing;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Init;

internal static class FileInit
{
    extension(IFileInit<StrictDefinition, RequiredInRequired> init)
    {
        public async ValueTask InitAsync(CancellationToken cancellationToken = default)
        {
            if (!await init.StorageBackend.ExistsAsync(init.GetLocation(), cancellationToken))
                await init.StorageBackend.CreateAsync(init.GetLocation(), cancellationToken);
        }
    }

    extension(IFileInit<ExternalDefinition, RequiredInRequired> init)
    {
        public async ValueTask InitAsync(CancellationToken cancellationToken = default)
        {
            if (!await init.StorageBackend.ExistsAsync(init.GetLocation(), cancellationToken).ConfigureAwait(false))
                throw new ExternalRequiredFileMissingException("A required, external file must exist.")
                {
                    Location = init.GetLocation(),
                    Key = init.GetKey()
                };
        }
    }

    extension(IFileInit<StrictDefinition, OptionalInRequired> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IFileInit<ExternalDefinition, OptionalInRequired> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IFileInit<StrictDefinition, OptionalInOptional> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IFileInit<ExternalDefinition, OptionalInOptional> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }
}
