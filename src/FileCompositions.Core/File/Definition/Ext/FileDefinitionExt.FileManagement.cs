using FileCompositions.Core.File.Quality.Ext;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Definition.Ext;

public static partial class FileDefinitionExt
{
    extension<TOwnership>(IFileDefinition<TOwnership, RequiredInRequired> definition)
        where TOwnership : DefinitionOwnership
    {

    }

    extension(IFileDefinition<StrictDefinition, OptionalInRequired> definition)
    {
        internal ValueTask CreateAsync(CancellationToken cancellationToken = default) =>
            definition.Context.StorageBackend.CreateAsync(definition.GetLocation(), cancellationToken);

        public async ValueTask DeleteAsync(CancellationToken cancellationToken = default)
        {
            if (await definition.Context.StorageBackend.ExistsAsync(definition.GetLocation(), cancellationToken).ConfigureAwait(false))
                await definition.Context.StorageBackend.DeleteAsync(definition.GetLocation(), cancellationToken).ConfigureAwait(false);
        }

        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            definition.Context.StorageBackend.ExistsAsync(definition.GetLocation(), cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInRequired> definition)
    {
        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            definition.Context.StorageBackend.ExistsAsync(definition.GetLocation(), cancellationToken);
    }

    extension(IFileDefinition<StrictDefinition, OptionalInOptional> definition)
    {
        internal async ValueTask<bool> TryCreateAsync(CancellationToken cancellationToken = default)
        {
            var addressExists = await definition.Context.StorageBackend.ExistsAsync(definition.GetLocation().Address, cancellationToken).ConfigureAwait(false);
            if (addressExists)
                await definition.Context.StorageBackend.CreateAsync(definition.GetLocation(), cancellationToken).ConfigureAwait(false);

            return addressExists;
        }

        public async ValueTask DeleteAsync(CancellationToken cancellationToken = default)
        {
            if (await definition.Context.StorageBackend.ExistsAsync(definition.GetLocation(), cancellationToken).ConfigureAwait(false))
                await definition.Context.StorageBackend.DeleteAsync(definition.GetLocation(), cancellationToken).ConfigureAwait(false);
        }

        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            definition.Context.StorageBackend.ExistsAsync(definition.GetLocation(), cancellationToken);
    }

    extension(IFileDefinition<ExternalDefinition, OptionalInOptional> definition)
    {
        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            definition.Context.StorageBackend.ExistsAsync(definition.GetLocation(), cancellationToken);
    }
}
