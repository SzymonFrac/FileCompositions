using FileCompositions.Core.Exception.ExternalRequiredMissing;
using FileCompositions.Core.File.Quality.Ext;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Definition.Ext;

public static partial class FileDefinitionExt
{
    extension(IFileDefinition<StrictDefinition, RequiredInRequired> init)
    {
        public async ValueTask InitAsync(CancellationToken cancellationToken = default)
        {
            if (!await init.Context.StorageBackend.ExistsAsync(init.GetLocation(), cancellationToken))
                await init.Context.StorageBackend.CreateAsync(init.GetLocation(), cancellationToken);
        }
    }

    extension(IFileDefinition<ExternalDefinition, RequiredInRequired> init)
    {
        public async ValueTask InitAsync(CancellationToken cancellationToken = default)
        {
            if (!await init.Context.StorageBackend.ExistsAsync(init.GetLocation(), cancellationToken).ConfigureAwait(false))
                throw new ExternalRequiredFileMissingException("A required, external file must exist.")
                {
                    Location = init.GetLocation(),
                    Key = init.Key
                };
        }
    }

    extension(IFileDefinition<StrictDefinition, OptionalInRequired> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInRequired> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IFileDefinition<StrictDefinition, OptionalInOptional> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInOptional> init)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }
}
