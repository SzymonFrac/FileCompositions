using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Operator.Specialized.Custom;

public static class CustomOperator
{
    extension(ICustomOperator<StrictDefinition, RequiredInRequired> @operator)
    {

    }

    extension(ICustomOperator<ExternalDefinition, RequiredInRequired> @operator)
    {

    }

    extension(ICustomOperator<StrictDefinition, OptionalInRequired> @operator)
    {
        public ValueTask CreateAsync(CancellationToken cancellationToken = default) =>
            @operator.StorageBackend.CreateAsync(@operator.GetLocation(), cancellationToken);

        public async ValueTask DeleteAsync(CancellationToken cancellationToken = default)
        {
            if (await @operator.StorageBackend.ExistsAsync(@operator.GetLocation(), cancellationToken).ConfigureAwait(false))
                await @operator.StorageBackend.DeleteAsync(@operator.GetLocation(), cancellationToken).ConfigureAwait(false);
        }
    }

    extension(ICustomOperator<ExternalDefinition, OptionalInRequired> @operator)
    {

    }

    extension(ICustomOperator<StrictDefinition, OptionalInOptional> @operator)
    {
        public async ValueTask<bool> TryCreateAsync(CancellationToken cancellationToken = default)
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

    extension(ICustomOperator<ExternalDefinition, OptionalInOptional> @operator)
    {

    }
}
