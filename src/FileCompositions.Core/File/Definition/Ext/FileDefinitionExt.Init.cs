using FileCompositions.Core.Exception.ExternalRequiredMissing;
using FileCompositions.Core.File.Quality.Ext;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Definition.Ext;

public static partial class FileDefinitionExt
{
    extension(IFileDefinition<StrictDefinition, RequiredInRequired> file)
    {
        public async ValueTask InitAsync(CancellationToken cancellationToken = default)
        {
            if (!await file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken))
                await file.Context.StorageBackend.CreateAsync(file.GetLocation(), cancellationToken);
        }
    }

    extension(IFileDefinition<ExternalDefinition, RequiredInRequired> file)
    {
        public async ValueTask InitAsync(CancellationToken cancellationToken = default)
        {
            if (!await file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false))
                throw new ExternalRequiredFileMissingException("A required, external file must exist.")
                {
                    Location = file.GetLocation(),
                    Key = file.Key
                };
        }
    }

    extension(IFileDefinition<StrictDefinition, OptionalInRequired> file)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInRequired> file)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IFileDefinition<StrictDefinition, OptionalInOptional> file)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInOptional> file)
    {
        public ValueTask InitAsync(CancellationToken cancellationToken = default) => ValueTask.CompletedTask;
    }
}
