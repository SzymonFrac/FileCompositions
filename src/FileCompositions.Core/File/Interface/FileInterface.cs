using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Interface;

public static class FileInterface
{
    extension<TOwnership>(IFileInterface<TOwnership, RequiredInRequired> @interface)
        where TOwnership : DefinitionOwnership
    {
        internal Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenReadAsync(@interface.GetLocation(), cancellationToken);
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenWriteAsync(@interface.GetLocation(), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenAppendAsync(@interface.GetLocation(), cancellationToken);
    }

    extension(IFileInterface<StrictDefinition, OptionalInRequired> @interface)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.GetLocation(), cancellationToken)
                : default;
        internal Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenWriteAsync(@interface.GetLocation(), cancellationToken);
        internal Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.OpenAppendAsync(@interface.GetLocation(), cancellationToken);

        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken);
    }

    extension(IFileInterface<ExternalDefinition, OptionalInRequired> @interface)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.GetLocation(), cancellationToken)
                : default;
        internal async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenWriteAsync(@interface.GetLocation(), cancellationToken)
                : default;
        internal async Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenAppendAsync(@interface.GetLocation(), cancellationToken)
                : default;

        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken);
    }

    extension(IFileInterface<StrictDefinition, OptionalInOptional> @interface)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.GetLocation(), cancellationToken)
                : default;
        internal async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation().Address, cancellationToken)
                ? await @interface.StorageBackend.OpenWriteAsync(@interface.GetLocation(), cancellationToken)
                : default;
        internal async Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation().Address, cancellationToken)
                ? await @interface.StorageBackend.OpenAppendAsync(@interface.GetLocation(), cancellationToken)
                : default;

        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken);
    }

    extension(IFileInterface<ExternalDefinition, OptionalInOptional> @interface)
    {
        internal async Task<Stream?> OpenReadAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenReadAsync(@interface.GetLocation(), cancellationToken)
                : default;
        internal async Task<Stream?> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenWriteAsync(@interface.GetLocation(), cancellationToken)
                : default;
        internal async Task<Stream?> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            await @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken)
                ? await @interface.StorageBackend.OpenAppendAsync(@interface.GetLocation(), cancellationToken)
                : default;

        public ValueTask<bool> Exists(CancellationToken cancellationToken = default) =>
            @interface.StorageBackend.ExistsAsync(@interface.GetLocation(), cancellationToken);
    }
}
