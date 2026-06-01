using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.Directory.Interface;

public static class DirectoryInterface
{
    extension<TOwnership>(IDirectoryInterface<TOwnership, RequiredDefinition> @interface)
        where TOwnership : DefinitionOwnership
    {
        public ValueTask CreateResource(StorageResourceName name, CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.CreateAsync(@interface.Address.With(name), cancellationToken);
    }

    extension(IDirectoryInterface<StrictDefinition, OptionalDefinition> @interface)
    {
        public ValueTask Create(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.CreateAsync(@interface.Address, cancellationToken);
        
        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.ExistsAsync(@interface.Address, cancellationToken);

        public async ValueTask<bool> TryCreateResource(StorageResourceName name, CancellationToken cancellationToken = default)
        {
            if (await @interface.StorageBackend.ExistsAsync(@interface.Address, cancellationToken))
                return false;
            
            await @interface.StorageBackend.CreateAsync(@interface.Address.With(name), cancellationToken);
            return true;
        }
    }

    extension(IDirectoryInterface<ExternalDefinition, OptionalDefinition> @interface)
    {
        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.ExistsAsync(@interface.Address, cancellationToken);

        public async ValueTask<bool> TryCreateResource(StorageResourceName name, CancellationToken cancellationToken = default)
        {
            if (await @interface.StorageBackend.ExistsAsync(@interface.Address, cancellationToken))
                return false;

            await @interface.StorageBackend.CreateAsync(@interface.Address.With(name), cancellationToken);
            return true;
        }
    }
}
