using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Directory.Interface;

public static class DirectoryInterface
{
    extension<TOwnership>(IDirectoryInterface<TOwnership, RequiredDefinition> @interface)
        where TOwnership : DefinitionOwnership
    {

    }

    extension(IDirectoryInterface<StrictDefinition, OptionalDefinition> @interface)
    {
        public ValueTask Create(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.CreateAsync(@interface.Address, cancellationToken);

        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.ExistsAsync(@interface.Address, cancellationToken);
    }

    extension(IDirectoryInterface<ExternalDefinition, OptionalDefinition> @interface)
    {
        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.ExistsAsync(@interface.Address, cancellationToken);
    }
}
