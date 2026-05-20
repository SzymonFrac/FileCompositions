using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.Directory.Interface.Extensions;

internal static class DirectoryInterfaceNecessity
{
    extension(IDirectoryInterface<RequiredDefinition> @interface)
    {
        public ValueTask CreateResource(StorageResourceName name, CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.Create(@interface.Address.With(name), cancellationToken);
    }

    extension(IDirectoryInterface<OptionalDefinition> @interface)
    {
        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.Exists(@interface.Address, cancellationToken);

        public async ValueTask<bool> TryCreateResource(StorageResourceName name, CancellationToken cancellationToken = default)
        {
            var result = await @interface.StorageBackend.Exists(@interface.Address, cancellationToken);
            if (result)
                await @interface.StorageBackend.Create(@interface.Address.With(name), cancellationToken);
            
            return result;
        }
    }
}
