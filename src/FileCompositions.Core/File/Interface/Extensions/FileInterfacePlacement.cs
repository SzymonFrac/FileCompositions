using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.Storage.Location;

namespace FileCompositions.Core.File.Interface.Extensions;

internal static class FileInterfacePlacement
{
    extension(IFileInterface<RequiredInRequired> @interface)
    {
        public Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenReadAsync(@interface.Location, cancellationToken);
        public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenReadAsync(@interface.Location, cancellationToken);

        public StorageLocation GetLocation() => @interface.Location;
    }

    extension(IFileInterface<OptionalInRequired> @interface)
    {
        public async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.Exists(@interface.Location, cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.Location, cancellationToken)
                : default;
        public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenWriteAsync(@interface.Location, cancellationToken);

        public StorageLocation GetLocation() => @interface.Location;
        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.Exists(@interface.Location, cancellationToken);
    }

    extension(IFileInterface<OptionalInOptional> @interface)
    {
        public async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.Exists(@interface.Location, cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.Location, cancellationToken)
                : default;
        public async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.Exists(@interface.Location, cancellationToken)
                ? await @interface.StorageBackend.OpenWriteAsync(@interface.Location, cancellationToken)
                : default;

        public StorageLocation GetLocation() => @interface.Location;
        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.Exists(@interface.Location, cancellationToken);
    }
}
