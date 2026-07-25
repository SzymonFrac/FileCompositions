using FileCompositions.Core.File.Quality.Ext;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Definition.Ext;

public static partial class FileDefinitionExt
{
    extension<TOwnership>(IFileDefinition<TOwnership, RequiredInRequired> file)
        where TOwnership : DefinitionOwnership
    {

    }

    extension(IFileDefinition<StrictDefinition, OptionalInRequired> file)
    {
        internal ValueTask CreateAsync(CancellationToken cancellationToken = default) =>
            file.Context.StorageBackend.CreateAsync(file.GetLocation(), cancellationToken);

        public async ValueTask DeleteAsync(CancellationToken cancellationToken = default)
        {
            if (await file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false))
                await file.Context.StorageBackend.DeleteAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false);
        }

        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInRequired> file)
    {
        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken);
    }

    extension(IFileDefinition<StrictDefinition, OptionalInOptional> file)
    {
        internal async ValueTask<bool> TryCreateAsync(CancellationToken cancellationToken = default)
        {
            var addressExists = await file.Context.StorageBackend.ExistsAsync(file.GetLocation().Address, cancellationToken).ConfigureAwait(false);
            if (addressExists)
                await file.Context.StorageBackend.CreateAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false);

            return addressExists;
        }

        public async ValueTask DeleteAsync(CancellationToken cancellationToken = default)
        {
            if (await file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false))
                await file.Context.StorageBackend.DeleteAsync(file.GetLocation(), cancellationToken).ConfigureAwait(false);
        }

        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInOptional> file)
    {
        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            file.Context.StorageBackend.ExistsAsync(file.GetLocation(), cancellationToken);
    }
}
