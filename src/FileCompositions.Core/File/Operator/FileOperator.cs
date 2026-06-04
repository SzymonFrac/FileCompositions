using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Operator;

public static class FileOperator
{
    extension(IFileOperator<StrictDefinition, RequiredInRequired> @operator)
    {

    }

    extension(IFileOperator<ExternalDefinition, RequiredInRequired> @operator)
    {

    }

    extension(IFileOperator<StrictDefinition, OptionalInRequired> @operator)
    {
        internal ValueTask CreateAsync(CancellationToken cancellationToken = default) =>
            @operator.StorageBackend.CreateAsync(@operator.GetLocation(), cancellationToken);

        public async ValueTask DeleteAsync(CancellationToken cancellationToken = default)
        {
            if (await @operator.StorageBackend.ExistsAsync(@operator.GetLocation(), cancellationToken).ConfigureAwait(false))
                await @operator.StorageBackend.DeleteAsync(@operator.GetLocation(), cancellationToken).ConfigureAwait(false);
        }
    }

    extension(IFileOperator<ExternalDefinition, OptionalInRequired> @operator)
    {

    }

    extension(IFileOperator<StrictDefinition, OptionalInOptional> @operator)
    {
        internal async ValueTask<bool> TryCreateAsync(CancellationToken cancellationToken = default)
        {
            var addressExists = await @operator.StorageBackend.ExistsAsync(@operator.GetLocation().Address, cancellationToken).ConfigureAwait(false);
            if (addressExists)
                await @operator.StorageBackend.CreateAsync(@operator.GetLocation(), cancellationToken).ConfigureAwait(false);

            return addressExists;
        }

        public async ValueTask DeleteAsync(CancellationToken cancellationToken = default)
        {
            if (await @operator.StorageBackend.ExistsAsync(@operator.GetLocation(), cancellationToken).ConfigureAwait(false))
                await @operator.StorageBackend.DeleteAsync(@operator.GetLocation(), cancellationToken).ConfigureAwait(false);
        }
    }

    extension(IFileOperator<ExternalDefinition, OptionalInOptional> @operator)
    {

    }
}
