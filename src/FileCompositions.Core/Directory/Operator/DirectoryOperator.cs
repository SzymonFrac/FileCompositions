using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Directory.Operator;

public static class DirectoryOperator
{
    extension(IDirectoryOperator<StrictDefinition, RequiredDefinition> @operator)
    {

    }

    extension(IDirectoryOperator<ExternalDefinition, RequiredDefinition> @operator)
    {

    }

    extension(IDirectoryOperator<StrictDefinition, OptionalDefinition> @operator)
    {
        public ValueTask CreateAsync(CancellationToken cancellationToken = default) =>
            @operator.StorageBackend.CreateAsync(@operator.GetAddress(), cancellationToken);

        public ValueTask DeleteAsync(CancellationToken cancellationToken = default) =>
            @operator.StorageBackend.DeleteAsync(@operator.GetAddress(), cancellationToken);

        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            @operator.StorageBackend.ExistsAsync(@operator.GetAddress(), cancellationToken);
    }

    extension(IDirectoryOperator<ExternalDefinition, OptionalDefinition> @operator)
    {
        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            @operator.StorageBackend.ExistsAsync(@operator.GetAddress(), cancellationToken);
    }
}
