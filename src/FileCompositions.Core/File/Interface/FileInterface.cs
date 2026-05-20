using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Core.Storage.Location;

namespace FileCompositions.Core.File.Interface;

public static class FileInterface
{
    extension(IFileInterface<RequiredInRequired> @interface)
    {
        internal Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenReadAsync(@interface.Location, cancellationToken);
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenWriteAsync(@interface.Location, cancellationToken);

        public StorageLocation GetLocation() => @interface.Location;
    }

    extension(IFileInterface<OptionalInRequired> @interface)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.Exists(@interface.Location, cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.Location, cancellationToken)
                : default;
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenWriteAsync(@interface.Location, cancellationToken);

        public StorageLocation GetLocation() => @interface.Location;
        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.Exists(@interface.Location, cancellationToken);
    }

    extension(IFileInterface<OptionalInOptional> @interface)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.Exists(@interface.Location, cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.Location, cancellationToken)
                : default;
        internal async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.Exists(@interface.Location, cancellationToken)
                ? await @interface.StorageBackend.OpenWriteAsync(@interface.Location, cancellationToken)
                : default;

        public StorageLocation GetLocation() => @interface.Location;
        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.Exists(@interface.Location, cancellationToken);
    }
}
